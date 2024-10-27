namespace DigitacaoProposta.Dominio.GravarProposta.Aplicacao
{
    public record CriarPropostaCommand(
        string CpfAgente,              
        string CpfCliente,             
        decimal ValorEmprestimo,       
        int NumeroParcelas,            
        bool Refinanciamento,
        string CodigoConveniada
        );
}
