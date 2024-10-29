using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.Regras.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testes.Unidade.RegrasValidacao
{
    public class ValidacaoConveniadaEstadoClienteTest
    {
        [Fact]
        public void DeveRetornarFalhaQuandoConveniadaNaoOperaNoEstadoDoCliente()
        {
            // Arrange
            var estadoResidencial = new Estado(Guid.NewGuid(), "Rio de Janeiro", "RJ", "21", restricaoDeValor: 0, true);
            var conveniada = new Conveniada(Guid.NewGuid(), "INSS", "CONV001", true, "SP");
            var cliente = new Cliente(
            id: Guid.NewGuid(),
            nome: "Maria Silva",
            cpf: "12345678900",
            dataNascimento: new DateTime(1980, 5, 1),
            rendimentoMensal: 4000,
            cidadeResidencial: "Rio de Janeiro",
            ufResidencial: "RJ",
            cidadeNaturalidade: "Rio de Janeiro",
            ufNaturalidade: "RJ",
            telefoneDDD: "21",
            telefone: "987654321",
            email: "maria.silva@example.com",
            sexo: Sexo.Feminino,
            statusCpf: StatusCpf.Liberado
            );

            var validacao = new ValidacaoConveniadaEstadoCliente();

            // Act
            var resultado = validacao.Validar(null, cliente, conveniada, estadoResidencial, 0, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("A conveniada não opera no estado de residência do cliente.", resultado.Error);
        }

        [Fact]
        public void DevePassarQuandoConveniadaOperaNoEstadoDoCliente()
        {
            // Arrange
            var estadoResidencial = new Estado(Guid.NewGuid(), "São Paulo", "SP", "11", restricaoDeValor: 0, true);
            var conveniada = new Conveniada(Guid.NewGuid(), "INSS", "CONV001", true, "SP");
            var cliente = new Cliente(
            id: Guid.NewGuid(),
            nome: "Maria Silva",
            cpf: "19117744091",
            dataNascimento: new DateTime(1980, 5, 1),
            rendimentoMensal: 4000,
            cidadeResidencial: "São Paulo",
            ufResidencial: "SP",
            cidadeNaturalidade: "Campinas",
            ufNaturalidade: "SP",
            telefoneDDD: "11",
            telefone: "987654321",
            email: "maria.silva@example.com",
            sexo: Sexo.Feminino,
            statusCpf: StatusCpf.Bloqueado
            );

            var validacao = new ValidacaoConveniadaEstadoCliente();

            // Act
            var resultado = validacao.Validar(null, cliente, conveniada, estadoResidencial, 0, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsSuccess);
        }
    }

}
