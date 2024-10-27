using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;

namespace DigitacaoProposta.Dominio.Regras.Validacoes
{
    public class ValidacaoCpfClienteLiberado : IValidarProposta
    {
        // 3 - Cpf deve estar liberado (não pode estar bloqueado);
        public Result Validar(Agente agente, Cliente cliente, Conveniada conveniada, Estado estadoResidencial, decimal valorEmprestimo, int numeroParcelas, TipoOperacao tipoOperacao)
        {
            if (cliente.CpfBloqueado())
                return Result.Failure("O CPF do cliente está bloqueado.");
            return Result.Success();
        }
    }
}
