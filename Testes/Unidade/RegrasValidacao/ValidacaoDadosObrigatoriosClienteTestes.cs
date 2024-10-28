using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.Regras.Validacoes;

namespace Testes.Unidade.Regras
{
    public class ValidacaoDadosObrigatoriosClienteTestes
    {
        [Fact]
        public void Deve_RetornarFalha_QuandoDadosObrigatoriosEmailETelefoneFaltam()
        {
            // Arrange
            var cliente = new Cliente(
            id: Guid.NewGuid(),
            nome: "Maria Silva",
            cpf: "19117744091",
            dataNascimento: new DateTime(1980, 5, 1),
            rendimentoMensal: 10,
            cidadeResidencial: "São Paulo",
            ufResidencial: "SP",
            cidadeNaturalidade: "Campinas",
            ufNaturalidade: "SP",
            telefoneDDD: "11",
            telefone: "",
            email: "",
            sexo: Sexo.Feminino,
            statusCpf: StatusCpf.Bloqueado
            );

            var validacao = new ValidacaoDadosObrigatoriosCliente();

            // Act
            var resultado = validacao.Validar(null, cliente, null, null, 0, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("Dados de contato obrigatórios faltando (telefone e email).", resultado.Error);
        }

        [Fact]
        public void Deve_RetornarFalha_QuandoDadosObrigatoriosRendimentoFaltam()
        {
            // Arrange
            var cliente = new Cliente(
            id: Guid.NewGuid(),
            nome: "Maria Silva",
            cpf: "19117744091",
            dataNascimento: new DateTime(1980, 5, 1),
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

            var validacao = new ValidacaoDadosObrigatoriosCliente();

            // Act
            var resultado = validacao.Validar(null, cliente, null, null, 0, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("Dados de rendimento obrigatórios estão faltando.", resultado.Error);
        }

        [Fact]
        public void Deve_Passar_QuandoDadosObrigatoriosPresentes()
        {
            // Arrange
            var cliente = new Cliente(
            id: Guid.NewGuid(),
            nome: "Maria Silva",
            cpf: "19117744091",
            dataNascimento: new DateTime(1980, 5, 1),
            rendimentoMensal: 1000,
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

            var validacao = new ValidacaoDadosObrigatoriosCliente();

            // Act
            var resultado = validacao.Validar(null, cliente, null, null, 0, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsSuccess);
        }
    }

}
