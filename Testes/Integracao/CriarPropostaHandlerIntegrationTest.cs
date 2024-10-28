using DigitacaoProposta.Dominio;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao;
using DigitacaoProposta.Dominio.GravarProposta.Infra;
using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.Regras.Validacoes.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.Integracao
{
    public class CriarPropostaHandlerIntegrationTest
    {
        private GravarPropostaDbContext CriarDbContextEmMemoria()
        {
            var options = new DbContextOptionsBuilder<GravarPropostaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new GravarPropostaDbContext(options);

            // Populando dados iniciais
            context.Agentes.Add(new Agente(Guid.NewGuid(), "Agente Ativo", "03691005063", StatusAgente.Ativo, "RS"));
            context.Clientes.Add(new Cliente(Guid.NewGuid(), "Maria Silva", "19117744091", new DateTime(1980, 5, 1), 4000, "São Paulo", "SP", "Campinas", "SP", "11", "987654321", "maria.silva@example.com", Sexo.Feminino, StatusCpf.Liberado));
            context.Conveniadas.Add(new Conveniada(Guid.NewGuid(), "INSS", "CONV001", aceitaRefinanciamento: true, uf: "SP"));
            context.Estados.Add(new Estado(Guid.NewGuid(), "São Paulo", "SP", "11", restricaoDeValor: 50000, requerAssinaturaHibrida: false));
            context.Estados.Add(new Estado(Guid.NewGuid(), "Rio Grande do Sul", "RS", "51", restricaoDeValor: 30000, requerAssinaturaHibrida: true));

            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task DeveCriarPropostaComSucessoQuandoRegrasForemAtendidas()
        {
            // Arrange
            var dbContext = CriarDbContextEmMemoria();
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

        //[Fact]
        //public async Task Deve_RetornarErro_ParaCpfClienteBloqueado()
        //{
        //    // Arrange
        //    var dbContext = CriarDbContextEmMemoria();
        //    var propostasRepositorio = new PropostasRepositorio(dbContext);
        //    var ruleFactory = new PropostaRuleFactory();
        //    var handler = new CriarPropostaHandler(propostasRepositorio, ruleFactory);

        //    var command = new CriarPropostaCommand(
        //        CpfAgente: "03691005063",
        //        CpfCliente: "12345678901",  // CPF bloqueado
        //        ValorEmprestimo: 20000,
        //        NumeroParcelas: 12,
        //        Refinanciamento: false,
        //        CodigoConveniada: "CONV001"
        //    );

        //    // Act
        //    var resultado = await handler.Handle(command, CancellationToken.None);

        //    // Assert
        //    Assert.True(resultado.IsFailure);
        //    Assert.Equal("O CPF do cliente está bloqueado.", resultado.Error);
        //}

    }
}
