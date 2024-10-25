using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;

namespace DigitacaoProposta.Dominio.Regras
{
    public interface IValidarProposta
    {
        Result Validar(Agente agente, Cliente cliente, Conveniada conveniada, Estado estado);
    }
}
