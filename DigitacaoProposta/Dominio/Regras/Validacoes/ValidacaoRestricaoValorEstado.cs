using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;

namespace DigitacaoProposta.Dominio.Regras.Validacoes
{
    public class ValidacaoRestricaoValorEstado : IValidarProposta
    {
        public Result Validar(Agente agente, Cliente cliente, Conveniada conveniada, Estado estadoResidencial, decimal valorEmprestimo, int numeroParcelas, TipoOperacao tipoOperacao)
        {
            if (!estadoResidencial.VerificarRestricaoDeValor(valorEmprestimo))
                return Result.Failure("O valor da operação excede o limite permitido no estado.");
            return Result.Success();
        }
    }
}
