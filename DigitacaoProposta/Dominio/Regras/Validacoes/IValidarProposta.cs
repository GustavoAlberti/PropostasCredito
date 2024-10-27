using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;

namespace DigitacaoProposta.Dominio.Regras.Validacoes
{
    public interface IValidarProposta
    {
        Result Validar(Agente agente, Cliente cliente, Conveniada conveniada, Estado estadoResidencial, decimal valorEmprestimo, int numeroParcelas, TipoOperacao tipoOperacao);
    }
}
