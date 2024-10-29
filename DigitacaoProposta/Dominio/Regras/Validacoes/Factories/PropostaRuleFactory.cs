using DigitacaoProposta.Dominio.GravarProposta;

namespace DigitacaoProposta.Dominio.Regras.Validacoes.Factories
{
    public class PropostaRuleFactory : IPropostaRuleFactory
    {
        public List<IValidarProposta> ObterRegras(TipoOperacao tipoOperacao)
        {
            var regras = new List<IValidarProposta>
            {
                new ValidacaoCpfClienteLiberado(),
                new ValidacaoDadosObrigatoriosCliente(),
                new ValidacaoIdadeLimite(),
                new ValidacaoRestricaoValorEstado(),
                new ValidacaoConveniadaEstadoCliente()
            };

            if (tipoOperacao == TipoOperacao.Refinanciamento)
            {
                regras.Add(new ValidacaoConveniadaAceitaRefinanciamento());
            }

            return regras;
        }
    }
}
