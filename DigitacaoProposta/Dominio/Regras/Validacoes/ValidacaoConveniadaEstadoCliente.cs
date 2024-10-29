using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao.DTO;

namespace DigitacaoProposta.Dominio.Regras.Validacoes
{
    public class ValidacaoConveniadaEstadoCliente : IValidarProposta
    {
        public Result Validar(Agente agente, Cliente cliente, Conveniada conveniada, Estado estadoResidencial, decimal valorEmprestimo, int numeroParcelas, TipoOperacao tipoOperacao)
        {
            if (conveniada.Uf != cliente.UfResidencial)
                return Result.Failure<PropostaResponseDto>("A conveniada não opera no estado de residência do cliente.");

            return Result.Success();
        }
    }
}
