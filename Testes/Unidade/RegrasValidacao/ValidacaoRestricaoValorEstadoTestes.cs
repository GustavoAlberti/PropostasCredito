using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.Regras.Validacoes;

namespace Testes.Unidade.Regras
{
    public class ValidacaoRestricaoValorEstadoTest
    {
        [Fact]
        public void Deve_RetornarFalha_QuandoValorExcedeRestricaoDoEstado()
        {
            // Arrange
            var estado = new Estado(Guid.NewGuid(), "Rio Grande do Sul", "RS", "51", restricaoDeValor: 50000, false);
            var validacao = new ValidacaoRestricaoValorEstado();

            // Act
            var resultado = validacao.Validar(null, null, null, estado, 60000, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("O valor da operação excede o limite permitido no estado.", resultado.Error);
        }

        [Fact]
        public void Deve_Passar_QuandoValorDentroDaRestricaoDoEstado()
        {
            // Arrage
            var estado = new Estado(Guid.NewGuid(), "São Paulo", "SP", "11", restricaoDeValor: 100000, true);
            var validacao = new ValidacaoRestricaoValorEstado();

            // Act
            var resultado = validacao.Validar(null, null, null, estado, 50000, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsSuccess);
        }
    }

}
