using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao.DTO;
using DigitacaoProposta.Dominio.GravarProposta.Infra;
using DigitacaoProposta.Dominio.Regras;
using DigitacaoProposta.Dominio.Regras.DefineTipoAssinatura;
using DigitacaoProposta.Dominio.Regras.Validacoes;

namespace DigitacaoProposta.Dominio.GravarProposta.Aplicacao
{
    public class CriarPropostaHandler(
        PropostasRepositorio propostasRepositorio)
    {

        public async Task<Result<PropostaResponseDto>> Handle(CriarPropostaCommand command, CancellationToken cancellationToken)
        {

            // 1. Validar agente ativo
            var agente = await propostasRepositorio.RecuperarAgente(command.CpfAgente);
            if (agente.HasNoValue || agente.Value.Status == StatusAgente.Inativo)
                return Result.Failure<PropostaResponseDto>("Agente inválido ou inativo.");

            // 2. Validar cliente
            var cliente = await propostasRepositorio.RecuperarCliente(command.CpfCliente);
            if (cliente.HasNoValue)
                return Result.Failure<PropostaResponseDto>("Cliente inválido.");

            // 3. Recuperar conveniada
            var conveniada = await propostasRepositorio.RecuperarConveniada(command.CodigoConveniada);
            if (conveniada.HasNoValue)
                return Result.Failure<PropostaResponseDto>("Conveniada não encontrada.");

            // 4. Recuperar estado e verificar restrições de valor
            var estadoResidencial = await propostasRepositorio.RecuperarEstado(cliente.Value.UfResidencial);
            var estadoNascimento = await propostasRepositorio.RecuperarEstado(cliente.Value.UfNaturalidade);

            if (estadoResidencial.HasNoValue || estadoNascimento.HasNoValue)
                return Result.Failure<PropostaResponseDto>("Estado residencial ou de nascimento não encontrado.");

            // 5. Verificar se o cliente já tem propostas abertas
            var propostasAbertas = await propostasRepositorio.ExistePropostaAberta(command.CpfCliente);
            if (propostasAbertas)
                return Result.Failure<PropostaResponseDto>("Já existe uma proposta aberta para este cliente.");

            TipoOperacao tipoOperacao = command.Refinanciamento ? TipoOperacao.Refinanciamento : TipoOperacao.ContratoNovo;

            var regras = new List<IValidarProposta>()
            {
                //dados de cliente
                new ValidacaoCpfClienteLiberado(),
                new ValidacaoDadosObrigatoriosCliente(),
                new ValidacaoIdadeLimite(),
                //dados de estado
                new ValidacaoRestricaoValorEstado(),
                //dados de conveniada:
                new ValidacaoConveniadaAceitaRefinanciamento(),
            };

            foreach (var regra in regras)
            {
                var resultado = regra.Validar(agente.Value, cliente.Value, conveniada.Value, estadoResidencial.Value, command.ValorEmprestimo, command.NumeroParcelas, tipoOperacao);
                if (resultado.IsFailure)
                    return Result.Failure<PropostaResponseDto>(resultado.Error);
            }

            var tipoAssinatura = DefinicaoTipoAssinatura.DeterminarTipoAssinatura(estadoResidencial.Value, estadoNascimento.Value, cliente.Value, tipoOperacao);
           
            var dataPrimeiraParcela = DateTime.Now.AddMonths(1);
            var dataUltimaParcela = dataPrimeiraParcela.AddMonths(command.NumeroParcelas - 1);

            var propostaResult = Proposta.Criar(
                id: Guid.NewGuid(),
                cpfCliente: command.CpfCliente,
                valorEmprestimo: command.ValorEmprestimo,
                numeroParcelas: command.NumeroParcelas,
                valorParcela: command.ValorEmprestimo / command.NumeroParcelas,
                dataPrimeiraParcela: dataPrimeiraParcela,
                dataUltimaParcela: dataUltimaParcela,
                agenteId: agente.Value.Id,
                conveniadaId: conveniada.Value.Id,
                dataCriacao: DateTime.Now,
                tipoOperacao: tipoOperacao,
                tipoAssinatura: tipoAssinatura
            );


            if (propostaResult.IsFailure)
                return Result.Failure<PropostaResponseDto>(propostaResult.Error);

            await propostasRepositorio.Adicionar(propostaResult.Value, cancellationToken);
            await propostasRepositorio.Save();

            var propostaResponse = PropostaResponseDto.FromEntity(propostaResult.Value, agente.Value.Nome, conveniada.Value.Nome);

            return Result.Success(propostaResponse);
        }
    }
}
