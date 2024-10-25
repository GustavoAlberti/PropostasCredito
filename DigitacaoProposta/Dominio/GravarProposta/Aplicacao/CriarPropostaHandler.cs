using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta.Infra;

namespace DigitacaoProposta.Dominio.GravarProposta.Aplicacao
{
    public class CriarPropostaHandler(
        PropostasRepositorio propostasRepositorio)
    {
        public async Task<Result<Proposta>> Handle(CriarPropostaCommand command, CancellationToken cancellationToken)
        {

            // 1. Validar agente ativo
            var agenteResult = await propostasRepositorio.RecuperarAgente(command.CpfAgente);
            if (agenteResult.HasNoValue || agenteResult.Value.Status == StatusAgente.Inativo)
                return Result.Failure<Proposta>("Agente inválido ou inativo.");

            var agente = agenteResult.Value;

            // 2. Validar cliente e status do CPF
            var clienteResult = await propostasRepositorio.RecuperarCliente(command.CpfCliente);
            if (clienteResult.HasNoValue)
                return Result.Failure<Proposta>("Cliente inválido.");

            var cliente = clienteResult.Value;

            if (cliente.CpfBloqueado())
                return Result.Failure<Proposta>("O CPF do cliente está bloqueado.");

            // Validar os dados obrigatórios do cliente
            if (string.IsNullOrEmpty(cliente.Telefone) || string.IsNullOrEmpty(cliente.Email))
                return Result.Failure<Proposta>("Dados de contato obrigatórios faltando (telefone e email).");

            if (cliente.RendimentoMensal <= 0)
                return Result.Failure<Proposta>("Dados de rendimento obrigatórios estão faltando.");

            // 3. Verificar se o cliente já tem propostas abertas
            var propostasAbertas = await propostasRepositorio.ExistePropostaAberta(command.CpfCliente);
            if (propostasAbertas)
                return Result.Failure<Proposta>("Já existe uma proposta aberta para este cliente.");

            // 4. Recuperar conveniada e verificar se aceita refinanciamento (se aplicável)
            var conveniadaResult = await propostasRepositorio.RecuperarConveniada(agente.ConveniadaId.ToString());
            if (conveniadaResult.HasNoValue)
                return Result.Failure<Proposta>("Conveniada não encontrada.");

            var conveniada = conveniadaResult.Value;

            if (command.Refinanciamento && !conveniada.AceitaRefin())
                return Result.Failure<Proposta>("A conveniada não aceita operações de refinanciamento.");

            // 5. Recuperar estado e verificar restrições de valor
            var estadoResult = await propostasRepositorio.RecuperarEstado(cliente.Uf);
            if (estadoResult.HasNoValue)
                return Result.Failure<Proposta>("Estado não encontrado.");

            var estado = estadoResult.Value;

            if (!estado.VerificarRestricaoDeValor(command.Valor))
                return Result.Failure<Proposta>("O valor da operação excede o limite permitido no estado.");

            // 6. Verificar se a idade máxima para a última parcela é respeitada
            var idade = cliente.CalcularIdade();
            if (idade + (command.QuantidadeParcelas / 12) > 80)
                return Result.Failure<Proposta>("A última parcela excede a idade máxima permitida de 80 anos.");

            // 7. Criar a proposta no domínio
            //var proposta = Proposta.Criar(Guid.NewGuid(), command.CpfCliente, command.Valor, command.QuantidadeParcelas, command.Refinanciamento, agente, conveniada);
            // 7. Criar a proposta no domínio
            var propostaResult = Proposta.Criar(
                id: Guid.NewGuid(),  // Gerar um novo Guid para a proposta
                cpfCliente: command.CpfCliente,
                valorEmprestimo: command.Valor,
                numeroParcelas: command.QuantidadeParcelas,
                valorParcela: command.Valor / command.QuantidadeParcelas,  // Calcula o valor de cada parcela
                dataPrimeiraParcela: DateTime.Now.AddMonths(1),  // Exemplo: a primeira parcela é no próximo mês
                agenteId: agente.Id,
                conveniadaId: conveniada.Id,
                dataCriacao: DateTime.Now,
                tipoOperacao: command.Refinanciamento ? TipoOperacao.Refinanciamento : TipoOperacao.Emprestimo);

            if (propostaResult.IsFailure)
                return Result.Failure<Proposta>(propostaResult.Error);

            // 8. Adicionar a proposta ao banco de dados
            await propostasRepositorio.Adicionar(propostaResult.Value, cancellationToken);
            await propostasRepositorio.Save();

            return Result.Success(propostaResult.Value);
        }
    }
}
