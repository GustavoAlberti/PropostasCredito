using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.Regras.Validacoes;

namespace Testes.Unidade.Regras
{
    public class ValidacaoConveniadaAceitaRefinanciamentoTest
    {
        [Fact]
        public void DeveRetornarFalhaQuandoConveniadaNaoAceitaRefinanciamento()
        {
            // Arrange
            var conveniada = new Conveniada(Guid.NewGuid(), "INSS", "CONV001", false, "RS");
            var validacao = new ValidacaoConveniadaAceitaRefinanciamento();

            // Act
            var resultado = validacao.Validar(null, null, conveniada, null, 0, 0, TipoOperacao.Refinanciamento);

            // Assert
            Assert.True(resultado.IsFailure);
            Assert.Equal("A conveniada não aceita operações de refinanciamento.", resultado.Error);
        }

        [Fact]
        public void DevePassarQuandoConveniadaAceitaRefinanciamento()
        {
            // Arrange
            var conveniada = new Conveniada(Guid.NewGuid(), "INSS", "CONV001", true, "RS");
            var validacao = new ValidacaoConveniadaAceitaRefinanciamento();

            // Act
            var resultado = validacao.Validar(null, null, conveniada, null, 0, 0, TipoOperacao.Refinanciamento);

            // Assert
            Assert.True(resultado.IsSuccess);
        }
    }

}
