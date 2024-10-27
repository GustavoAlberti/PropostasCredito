using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.GravarProposta.Aplicacao.DTO;

namespace DigitacaoProposta.Dominio.Regras.Validacoes
{
    public class ValidacaoDadosObrigatoriosCliente : IValidarProposta
    {
        public Result Validar(Agente agente, Cliente cliente, Conveniada conveniada, Estado estadoResidencial, decimal valorEmprestimo, int numeroParcelas, TipoOperacao tipoOperacao)
        {
            //Cpf, dados de rendimento, endereço e (dados de contato (telefone, email) obrigatórios)
            if (string.IsNullOrEmpty(cliente.Telefone) || string.IsNullOrEmpty(cliente.Email))
                return Result.Failure("Dados de contato obrigatórios faltando (telefone e email).");

            return cliente.RendimentoMensal > 0 ? Result.Success() : Result.Failure("Dados de rendimento obrigatórios estão faltando.");
        }
    }
}
