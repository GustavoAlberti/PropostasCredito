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
            var conveniada = new Conveniada(Guid.NewGuid(), "INSS", "CONV001", true, "RS");
            var validacao = new ValidacaoRestricaoValorEstado();

            // Act
            var resultado = validacao.Validar(null, null, conveniada, estado, 60000, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("O valor da operação excede o limite permitido no estado.", resultado.Error);
        }

        [Fact]
        public void Deve_Passar_QuandoValorDentroDaRestricaoDoEstado()
        {
            // Arrage
            var estado = new Estado(Guid.NewGuid(), "São Paulo", "SP", "11", restricaoDeValor: 100000, true);
            var conveniada = new Conveniada(Guid.NewGuid(), "SIAPE", "CONV002", true, "SP");
            var validacao = new ValidacaoRestricaoValorEstado();

            // Act
            var resultado = validacao.Validar(null, null, conveniada, estado, 50000, 0, TipoOperacao.ContratoNovo);

            // Assert
            Assert.True(resultado.IsSuccess);
        }
    }

}
