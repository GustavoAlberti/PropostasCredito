using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao;
using DigitacaoProposta.Dominio.GravarProposta.Infra;
using DigitacaoProposta.Dominio.Regras.Validacoes.Factories;
using Testes.Integracao.Helper;

namespace Testes.Integracao
{
    public class CriarPropostaHandlerIntegrationTest2
    {
        [Fact]
        public async Task DeveCriarPropostaComSucessoQuandoRegrasForemAtendidas()
        {
            // Arrange
            var dbContext = DbContextHelper.CriarDbContextEmMemoria();
            DbContextSeeder.PopularDadosIniciais(dbContext);

            var propostasRepositorio = new PropostasRepositorio(dbContext);
            var ruleFactory = new PropostaRuleFactory();
            var handler = new CriarPropostaHandler(propostasRepositorio, ruleFactory);

            var command = new CriarPropostaCommand(
                CpfAgente: "03691005063",
                CpfCliente: "19117744091",
                ValorEmprestimo: 5000,
                NumeroParcelas: 12,
                Refinanciamento: false,
                CodigoConveniada: "CONV001"
            );

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado.IsSuccess);
            Assert.NotNull(resultado.Value);
            Assert.Equal(command.CpfCliente, resultado.Value.CpfCliente);
            Assert.Equal(command.ValorEmprestimo, resultado.Value.ValorEmprestimo);
        }

        [Fact]
        public async Task DeveFalharQuandoClienteJaPossuiPropostaAberta()
        {
            // Arrange
            var dbContext = DbContextHelper.CriarDbContextEmMemoria();
            DbContextSeeder.PopularDadosIniciais(dbContext);

            var propostasRepositorio = new PropostasRepositorio(dbContext);
            var ruleFactory = new PropostaRuleFactory();
            var handler = new CriarPropostaHandler(propostasRepositorio, ruleFactory);

            var propostaExistenteResult = Proposta.Criar(
                id: Guid.NewGuid(),
                cpfCliente: "19117744091",
                valorEmprestimo: 1000,
                numeroParcelas: 5,
                agenteId: dbContext.Agentes.First().Id,
                conveniadaId: dbContext.Conveniadas.First().Id,
                tipoOperacao: TipoOperacao.ContratoNovo,
                tipoAssinatura: TipoAssinatura.Eletronica
            );

            dbContext.Propostas.Add(propostaExistenteResult.Value);
            dbContext.SaveChanges();

            var command = new CriarPropostaCommand(
                CpfAgente: "03691005063",
                CpfCliente: "19117744091",
                ValorEmprestimo: 5000,
                NumeroParcelas: 12,
                Refinanciamento: false,
                CodigoConveniada: "CONV001"
            );

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("Já existe uma proposta aberta para este cliente.", resultado.Error);
        }

        [Fact]
        public async Task DeveFalharQuandoAgenteInvalidoOuInativo()
        {
            // Arrange
            var dbContext = DbContextHelper.CriarDbContextEmMemoria();
            DbContextSeeder.PopularDadosIniciais(dbContext);

            var propostasRepositorio = new PropostasRepositorio(dbContext);
            var ruleFactory = new PropostaRuleFactory();
            var handler = new CriarPropostaHandler(propostasRepositorio, ruleFactory);

            var command = new CriarPropostaCommand(
                CpfAgente: "00000000000",
                CpfCliente: "19117744091",
                ValorEmprestimo: 5000,
                NumeroParcelas: 12,
                Refinanciamento: false,
                CodigoConveniada: "CONV001"
            );

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("Agente inválido ou inativo.", resultado.Error);
        }

        [Fact]
        public async Task DeveFalharQuandoClienteInvalido()
        {
            // Arrange
            var dbContext = DbContextHelper.CriarDbContextEmMemoria();
            DbContextSeeder.PopularDadosIniciais(dbContext);

            var propostasRepositorio = new PropostasRepositorio(dbContext);
            var ruleFactory = new PropostaRuleFactory();
            var handler = new CriarPropostaHandler(propostasRepositorio, ruleFactory);

            var command = new CriarPropostaCommand(
                CpfAgente: "03691005063",
                CpfCliente: "00000000000",
                ValorEmprestimo: 5000,
                NumeroParcelas: 12,
                Refinanciamento: false,
                CodigoConveniada: "CONV001"
            );

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("Cliente inválido.", resultado.Error);
        }

        [Fact]
        public async Task DeveFalharQuandoConveniadaNaoEncontrada()
        {
            // Arrange
            var dbContext = DbContextHelper.CriarDbContextEmMemoria();
            DbContextSeeder.PopularDadosIniciais(dbContext);

            var propostasRepositorio = new PropostasRepositorio(dbContext);
            var ruleFactory = new PropostaRuleFactory();
            var handler = new CriarPropostaHandler(propostasRepositorio, ruleFactory);

            var command = new CriarPropostaCommand(
                CpfAgente: "03691005063",
                CpfCliente: "19117744091",
                ValorEmprestimo: 5000,
                NumeroParcelas: 12,
                Refinanciamento: false,
                CodigoConveniada: "CONV999"
            );

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("Conveniada não encontrada.", resultado.Error);
        }

        [Fact]
        public async Task DeveFalharQuandoEstadoResidencialOuNascimentoNaoEncontrado()
        {
            // Arrange
            var dbContext = DbContextHelper.CriarDbContextEmMemoria();
            DbContextSeeder.PopularDadosIniciais(dbContext);

            var propostasRepositorio = new PropostasRepositorio(dbContext);
            var ruleFactory = new PropostaRuleFactory();
            var handler = new CriarPropostaHandler(propostasRepositorio, ruleFactory);

            var clienteUFInvalido = new Cliente(Guid.NewGuid(), "Maria Silva", "00000000000", new DateTime(1980, 5, 1), 4000, "São Paulo", "XX", "Campinas", "XX", "11", "987654321", "maria.silva@example.com", Sexo.Feminino, StatusCpf.Liberado);
            
            dbContext.Clientes.Add(clienteUFInvalido);
            dbContext.SaveChanges();

            var command = new CriarPropostaCommand(
                CpfAgente: "03691005063",
                CpfCliente: clienteUFInvalido.Cpf,
                ValorEmprestimo: 5000,
                NumeroParcelas: 12,
                Refinanciamento: false,
                CodigoConveniada: "CONV001"
            );

            // Act
            var resultado = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("Estado residencial ou de nascimento não encontrado.", resultado.Error);
        }

    }

}
