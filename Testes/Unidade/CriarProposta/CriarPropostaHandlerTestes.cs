using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao;
using DigitacaoProposta.Dominio.GravarProposta.Infra;
using DigitacaoProposta.Dominio.Regras.Validacoes.Factories;
using DigitacaoProposta.Dominio.Regras.Validacoes;
using Moq;

namespace Testes.Unidade.CriarProposta
{
    public class CriarPropostaHandlerTestes
    {
        //[Fact]
        //public async Task DeveCriarPropostaComSucessoQuandoRegrasForemAtendidas()
        //{
        //    // Arrange
        //    var command = new CriarPropostaCommand(
        //        CpfAgente: "03691005063",
        //        CpfCliente: "19117744091",
        //        ValorEmprestimo: 5000,
        //        NumeroParcelas: 12,
        //        Refinanciamento: false,
        //        CodigoConveniada: "CONV001"
        //    );

        //    //var fakeRepositorio = new FakePropostasRepositorio();
        //    //var handler = new CriarPropostaHandler(fakeRepositorio);

        //    //Ver com Bruno amanhã. ou usar uma interface.

        //    var mockRepositorio = new Mock<PropostasRepositorio>();

        //    var agente = new Agente(Guid.NewGuid(), "Agente Ativo", "02336126541", StatusAgente.Ativo, "RS");
        //    var cliente = new Cliente(Guid.NewGuid(), "Maria Silva", "19117744091", new DateTime(1980, 5, 1), 4000, "São Paulo", "SP", "Campinas", "SP", "11", "987654321", "maria.silva@example.com", Sexo.Feminino, StatusCpf.Bloqueado);
        //    var conveniada = new Conveniada(Guid.NewGuid(), "INSS", "CONV001", false, "RS");
        //    var estado = new Estado(Guid.NewGuid(), "Rio Grande do Sul", "RS", "51", restricaoDeValor: 50000, false);

        //    mockRepositorio.Setup(repo => repo.RecuperarAgente(It.IsAny<string>()))
        //        .ReturnsAsync(Maybe<Agente>.From(agente));

        //    mockRepositorio.Setup(repo => repo.RecuperarCliente(It.IsAny<string>()))
        //        .ReturnsAsync(Maybe<Cliente>.From(cliente));

        //    mockRepositorio.Setup(repo => repo.RecuperarConveniada(It.IsAny<string>()))
        //        .ReturnsAsync(Maybe<Conveniada>.From(conveniada));

        //    mockRepositorio.Setup(repo => repo.RecuperarEstado(It.IsAny<string>()))
        //        .ReturnsAsync(Maybe<Estado>.From(estado));

        //    mockRepositorio.Setup(repo => repo.ExistePropostaAberta(It.IsAny<string>()))
        //        .ReturnsAsync(false);

        //    // Mock da fábrica de regras
        //    var mockRuleFactory = new Mock<IPropostaRuleFactory>();
        //    var regrasMock = new List<IValidarProposta>
        //    {
        //        new ValidacaoCpfClienteLiberado(),
        //        new ValidacaoDadosObrigatoriosCliente(),
        //        new ValidacaoIdadeLimite(),
        //        new ValidacaoRestricaoValorEstado(),
        //        new ValidacaoConveniadaAceitaRefinanciamento()
        //    };
        //    mockRuleFactory.Setup(factory => factory.ObterRegras(It.IsAny<TipoOperacao>())).Returns(regrasMock);


        //    var handler = new CriarPropostaHandler(mockRepositorio.Object, mockRuleFactory.Object);

        //    // Act
        //    var resultado = await handler.Handle(command, CancellationToken.None);

        //    // Assert
        //    Assert.True(resultado.IsSuccess);
        //    Assert.NotNull(resultado.Value);
        //    Assert.Equal(command.CpfCliente, resultado.Value.CpfCliente);
        //    Assert.Equal(command.ValorEmprestimo, resultado.Value.ValorEmprestimo);
        //}

        //[Fact]
        //public async Task NaoDeveCriarPropostaQuandoClienteJaPossuiPropostaAberta()
        //{
        //    // Arrange
        //    var command = new CriarPropostaCommand(
        //        CpfAgente: "03691005063",
        //        CpfCliente: "19117744091",
        //        ValorEmprestimo: 5000,
        //        NumeroParcelas: 12,
        //        Refinanciamento: false,
        //        CodigoConveniada: "CONV001"
        //        );

        //    var mockRepositorio = new Mock<PropostasRepositorio>();

            
        //    mockRepositorio.Setup(repo => repo.ExistePropostaAberta(It.IsAny<string>())).ReturnsAsync(true);

        //    // Mock da fábrica de regras
        //    var mockRuleFactory = new Mock<IPropostaRuleFactory>();
        //    var regrasMock = new List<IValidarProposta>
        //    {
        //        new ValidacaoCpfClienteLiberado(),
        //        new ValidacaoDadosObrigatoriosCliente(),
        //        new ValidacaoIdadeLimite(),
        //        new ValidacaoRestricaoValorEstado(),
        //        new ValidacaoConveniadaAceitaRefinanciamento()
        //    };
        //    mockRuleFactory.Setup(factory => factory.ObterRegras(It.IsAny<TipoOperacao>())).Returns(regrasMock);

        //    var handler = new CriarPropostaHandler(mockRepositorio.Object, mockRuleFactory.Object);

        //    // Act
        //    var resultado = await handler.Handle(command, CancellationToken.None);

        //    // Assert
        //    Assert.True(resultado.IsFailure);
        //    Assert.Equal("Já existe uma proposta aberta para este cliente.", resultado.Error);
        //}

    }

}
