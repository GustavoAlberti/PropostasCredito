using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao.DTO;
using DigitacaoProposta.Dominio.GravarProposta.Infra;

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

            // 2. Validar cliente e status do CPF
            var cliente = await propostasRepositorio.RecuperarCliente(command.CpfCliente);
            if (cliente.HasNoValue)
                return Result.Failure<PropostaResponseDto>("Cliente inválido.");

            if (cliente.Value.CpfBloqueado())
                return Result.Failure<PropostaResponseDto>("O CPF do cliente está bloqueado.");

            // Validar os dados obrigatórios do cliente
            if (string.IsNullOrEmpty(cliente.Value.Telefone) || string.IsNullOrEmpty(cliente.Value.Email))
                return Result.Failure<PropostaResponseDto>("Dados de contato obrigatórios faltando (telefone e email).");

            if (cliente.Value.RendimentoMensal <= 0)
                return Result.Failure<PropostaResponseDto>("Dados de rendimento obrigatórios estão faltando.");

            // 3. Verificar se o cliente já tem propostas abertas
            var propostasAbertas = await propostasRepositorio.ExistePropostaAberta(command.CpfCliente);
            if (propostasAbertas)
                return Result.Failure<PropostaResponseDto>("Já existe uma proposta aberta para este cliente.");

            // 4. Recuperar conveniada e verificar se aceita refinanciamento
            var conveniada = await propostasRepositorio.RecuperarConveniada(command.Conveniada);
            if (conveniada.HasNoValue)
                return Result.Failure<PropostaResponseDto>("Conveniada não encontrada.");

            if (command.Refinanciamento && !conveniada.Value.AceitaRefin())
                return Result.Failure<PropostaResponseDto>("A conveniada não aceita operações de refinanciamento.");

            // 5. Recuperar estado e verificar restrições de valor
            var estadocliente = await propostasRepositorio.RecuperarEstado(cliente.Value.UfResidencial);
            if (estadocliente.HasNoValue)
                return Result.Failure<PropostaResponseDto>("Estado não encontrado.");

            if (!estadocliente.Value.VerificarRestricaoDeValor(command.ValorEmprestimo))
                return Result.Failure<PropostaResponseDto>("O valor da operação excede o limite permitido no estado.");

            // 6. Verificar se a idade máxima para a última parcela é respeitada
            var idade = cliente.Value.CalcularIdade();

            if (idade + (command.NumeroParcelas / 12) > 80)
                return Result.Failure<PropostaResponseDto>("A última parcela excede a idade máxima permitida de 80 anos.");


            // 7. Definir o tipo de assinatura
            TipoAssinatura tipoAssinatura;
            if (estadocliente.Value.RequerAssinaturaHibrida)
            {
                tipoAssinatura = TipoAssinatura.Hibrida;
            }
            else if (estadocliente.Value.Ddd == cliente.Value.TelefoneDDD)
            {
                tipoAssinatura = TipoAssinatura.Eletronica;
            }
            else
            {
                tipoAssinatura = TipoAssinatura.Figital;
            }

            // 8. Criar a proposta no domínio
            var propostaResult = Proposta.Criar(
                id: Guid.NewGuid(),
                cpfCliente: command.CpfCliente,
                valorEmprestimo: command.ValorEmprestimo,
                numeroParcelas: command.NumeroParcelas,
                valorParcela: command.ValorEmprestimo / command.NumeroParcelas,
                dataPrimeiraParcela: DateTime.Now.AddMonths(1),
                agenteId: agente.Value.Id,
                conveniadaId: conveniada.Value.Id,
                dataCriacao: DateTime.Now,
                tipoOperacao: command.Refinanciamento ? TipoOperacao.Refinanciamento : TipoOperacao.ContratoNovo,
                tipoAssinatura: tipoAssinatura
            );


            if (propostaResult.IsFailure)
                return Result.Failure<PropostaResponseDto>(propostaResult.Error);

            // 8. Adicionar a proposta ao banco de dados
            await propostasRepositorio.Adicionar(propostaResult.Value, cancellationToken);
            await propostasRepositorio.Save();

            var propostaResponse = PropostaResponseDto.FromEntity(propostaResult.Value, agente.Value.Nome, conveniada.Value.Nome);

            return Result.Success(propostaResponse);
        }
    }
}
