using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;

namespace DigitacaoProposta.Dominio.Regras.DefineTipoAssinatura
{
    public class DefinicaoTipoAssinatura
    {
        public static TipoAssinatura DeterminarTipoAssinatura(Estado estadoResidencial, Estado estadoNascimento, Cliente cliente, TipoOperacao tipoOperacao)
        {
            if (tipoOperacao == TipoOperacao.ContratoNovo)
            {
                if (estadoResidencial.RequerAssinaturaHibrida)
                {
                    return TipoAssinatura.Hibrida;
                }
                else if (estadoNascimento.Ddd == cliente.TelefoneDDD)
                {
                    return TipoAssinatura.Eletronica;
                }
            }

            return TipoAssinatura.Figital;
        }

    }
}
