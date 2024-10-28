using DigitacaoProposta.Dominio.GravarProposta;

namespace DigitacaoProposta.Dominio.Regras.Validacoes.Factories
{
    public interface IPropostaRuleFactory
    {
        List<IValidarProposta> ObterRegras(TipoOperacao tipoOperacao);
    }
}
