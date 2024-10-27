namespace DigitacaoProposta.Dominio.GravarProposta.Aplicacao.DTO
{
    public record PropostaResponseDto(
        string CpfCliente,
        decimal ValorEmprestimo,
        int NumeroParcelas,
        decimal ValorParcela,
        string DataPrimeiraParcela,
        string NomeAgente,
        string NomeConveniada,
        string DataCriacao,
        string Status,
        string TipoOperacao,
        Guid Id)
    {
        public static PropostaResponseDto FromEntity(Proposta proposta, string nomeAgente, string nomeConveniada) =>
            new PropostaResponseDto(
                proposta.CpfCliente,
                proposta.ValorEmprestimo,
                proposta.NumeroParcelas,
                Math.Round(proposta.ValorParcela, 2),
                proposta.DataPrimeiraParcela.ToString("dd-MM-yyyy"),
                nomeAgente,
                nomeConveniada,
                proposta.DataCriacao.ToString("dd-MM-yyyy"),
                proposta.Status.ToString(),
                proposta.TipoOperacao.ToString(),
                proposta.Id);
    }

}
