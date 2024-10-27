using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DigitacaoProposta.Dominio.Regras.Validacoes
{
    public class ValidacaoConveniadaAceitaRefinanciamento : IValidarProposta
    {
        public Result Validar(Agente agente, Cliente cliente, Conveniada conveniada, Estado estadoResidencial, decimal valorEmprestimo, int numeroParcelas, TipoOperacao tipoOperacao)
        {
            //Algumas conveniadas não aceitam operação de refinanciamento;
            if (tipoOperacao == TipoOperacao.Refinanciamento && !conveniada.AceitaRefin())
                return Result.Failure<PropostaResponseDto>("A conveniada não aceita operações de refinanciamento.");
            return Result.Success();
        }
    }
}
