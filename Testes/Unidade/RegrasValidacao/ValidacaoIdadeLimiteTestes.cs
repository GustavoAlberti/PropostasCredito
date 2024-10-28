using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.Regras.Validacoes;

namespace Testes.Unidade.Regras
{
    public class ValidacaoIdadeLimiteTest
    {
        [Fact]
        public void DeveRetornarFalhaQuandoUltimaParcelaExcedeLimiteDeIdade()
        {
            // Arrange
            var cliente = new Cliente(
            id: Guid.NewGuid(),
            nome: "Maria Silva",
            cpf: "19117744091",
            dataNascimento: new DateTime(1960, 1, 1),
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

            var validacao = new ValidacaoIdadeLimite();

            // Act
            var resultado = validacao.Validar(null, cliente, null, null, 0, 300, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("A última parcela excede a idade máxima permitida de 80 anos.", resultado.Error);
        }

        [Fact]
        public void DevePassarQuandoUltimaParcelaDentroDoLimiteDeIdade()
        {
            // Arrange
            var cliente = new Cliente(
            id: Guid.NewGuid(),
            nome: "Maria Silva",
            cpf: "19117744091",
            dataNascimento: new DateTime(1990, 5, 1),
            rendimentoMensal: 0,
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

            var validacao = new ValidacaoIdadeLimite();

            // Act
            var resultado = validacao.Validar(null, cliente, null, null, 0, 60, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsSuccess);
        }
    }

}
