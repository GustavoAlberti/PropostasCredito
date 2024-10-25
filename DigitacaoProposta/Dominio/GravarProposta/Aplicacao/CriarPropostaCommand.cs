namespace DigitacaoProposta.Dominio.GravarProposta.Aplicacao
{
    public record CriarPropostaCommand(
        string CpfAgente,
        string CpfCliente,
        decimal Valor,
        int QuantidadeParcelas,
        bool Refinanciamento);

}
