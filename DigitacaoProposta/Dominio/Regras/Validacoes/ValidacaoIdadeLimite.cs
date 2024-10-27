using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;

namespace DigitacaoProposta.Dominio.Regras.Validacoes
{
    public class ValidacaoIdadeLimite : IValidarProposta
    {
        public Result Validar(Agente agente, Cliente cliente, Conveniada conveniada, Estado estadoResidencial, decimal valorEmprestimo, int numeroParcelas, TipoOperacao tipoOperacao)
        {
            DateTime dataPrimeiraParcela = DateTime.Now.AddMonths(1);
            DateTime dataUltimaParcela = dataPrimeiraParcela.AddMonths(numeroParcelas - 1);

            int idadeClienteUltimaParcela = dataUltimaParcela.Year - cliente.DataNascimento.Year;
            if (idadeClienteUltimaParcela > 80)
                return Result.Failure("A última parcela excede a idade máxima permitida de 80 anos");
            return Result.Success();
        }
    }
}
