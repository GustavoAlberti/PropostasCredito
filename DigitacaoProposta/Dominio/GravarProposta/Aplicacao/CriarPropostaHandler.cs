using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao.DTO;
using DigitacaoProposta.Dominio.GravarProposta.Infra;
using DigitacaoProposta.Dominio.Regras.DefineTipoAssinatura;
using DigitacaoProposta.Dominio.Regras.Validacoes;
using DigitacaoProposta.Dominio.Regras.Validacoes.Factories;

namespace DigitacaoProposta.Dominio.GravarProposta.Aplicacao
{
    public class CriarPropostaHandler
    {
        private readonly PropostasRepositorio _propostaRepositorio;
        private readonly IPropostaRuleFactory _propostaRuleFactory;

        public CriarPropostaHandler(PropostasRepositorio propostaRepositorio, IPropostaRuleFactory propostaRuleFactory)
        {
            _propostaRepositorio = propostaRepositorio;
            _propostaRuleFactory = propostaRuleFactory;
        }

        public async Task<Result<PropostaResponseDto>> Handle(CriarPropostaCommand command, CancellationToken cancellationToken)
        {
            var agente = await _propostaRepositorio.RecuperarAgente(command.CpfAgente);
            if (agente.HasNoValue || agente.Value.Status == StatusAgente.Inativo)
                return Result.Failure<PropostaResponseDto>("Agente inválido ou inativo.");

            var cliente = await _propostaRepositorio.RecuperarCliente(command.CpfCliente);
            if (cliente.HasNoValue)
                return Result.Failure<PropostaResponseDto>("Cliente inválido.");
            
            var conveniada = await _propostaRepositorio.RecuperarConveniada(command.CodigoConveniada);
            if (conveniada.HasNoValue)
                return Result.Failure<PropostaResponseDto>("Conveniada não encontrada.");

            var estadoResidencial = await _propostaRepositorio.RecuperarEstado(cliente.Value.UfResidencial);
            var estadoNascimento = await _propostaRepositorio.RecuperarEstado(cliente.Value.UfNaturalidade);
            if (estadoResidencial.HasNoValue || estadoNascimento.HasNoValue)
                return Result.Failure<PropostaResponseDto>("Estado residencial ou de nascimento não encontrado.");

            var propostasAbertas = await _propostaRepositorio.ExistePropostaAberta(command.CpfCliente);
            if (propostasAbertas)
                return Result.Failure<PropostaResponseDto>("Já existe uma proposta aberta para este cliente.");

            TipoOperacao tipoOperacao = command.Refinanciamento ? TipoOperacao.Refinanciamento : TipoOperacao.ContratoNovo;
            var regras = _propostaRuleFactory.ObterRegras(tipoOperacao);

            foreach (var regra in regras)
            {
                var resultado = regra.Validar(agente.Value, cliente.Value, conveniada.Value, estadoResidencial.Value, command.ValorEmprestimo, command.NumeroParcelas, tipoOperacao);
                if (resultado.IsFailure)
                    return Result.Failure<PropostaResponseDto>(resultado.Error);
            }

            var tipoAssinatura = DefinicaoTipoAssinatura.DeterminarTipoAssinatura(estadoResidencial.Value, estadoNascimento.Value, cliente.Value, tipoOperacao);
           
            var propostaResult = Proposta.Criar(
                id: Guid.NewGuid(),
                cpfCliente: command.CpfCliente,
                valorEmprestimo: command.ValorEmprestimo,
                numeroParcelas: command.NumeroParcelas,
                agenteId: agente.Value.Id,
                conveniadaId: conveniada.Value.Id,
                tipoOperacao: tipoOperacao,
                tipoAssinatura: tipoAssinatura
            );

            if (propostaResult.IsFailure)
                return Result.Failure<PropostaResponseDto>(propostaResult.Error);

            await _propostaRepositorio.Adicionar(propostaResult.Value, cancellationToken);
            await _propostaRepositorio.Save();

            var propostaResponse = PropostaResponseDto.FromEntity(propostaResult.Value, agente.Value.Nome, conveniada.Value.Nome);
            return Result.Success(propostaResponse);
        }
    }
}
