using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.Regras.Validacoes;

namespace Testes.Unidade.Regras
{
    public class ValidacaoCpfClienteLiberadoTestes
    {
        [Fact]
        public void DeveRetornarFalhaQuandoCpfClienteBloqueado()
        {
            // Arrange
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

            var validacao = new ValidacaoCpfClienteLiberado();

            // Act
            var resultado = validacao.Validar(null, cliente, null, null, 0, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("O CPF do cliente está bloqueado.", resultado.Error);
        }

        [Fact]
        public void DevePassarQuandoCpfClienteLiberado()
        {
            // Arrange
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
            statusCpf: StatusCpf.Liberado
            );

            var validacao = new ValidacaoCpfClienteLiberado();

            // Act
            var resultado = validacao.Validar(null, cliente, null, null, 0, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsSuccess);
        }
    }

}
