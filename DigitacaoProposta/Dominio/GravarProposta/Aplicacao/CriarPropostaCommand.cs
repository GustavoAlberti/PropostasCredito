namespace DigitacaoProposta.Dominio.GravarProposta.Aplicacao
{
    public record CriarPropostaCommand(
        string CpfAgente,
        string Cpf,
        EnderecoDto Endereco,
        TelefoneDto Telefone,
        DadosBasicosDto DadosBasicos,
        OperacaoDto Operacao);

    public record EnderecoDto(string Cep, string Logradouro, string Numero, string Bairro, string Cidade, string Uf);
    public record TelefoneDto(string Ddd, string Numero);
    public record DadosBasicosDto(string Nome, DateTime DataNascimento, string Sexo, decimal RendimentoMensal);
    public record OperacaoDto(decimal Valor, int QuantidadeParcelas, bool Refinanciamento);

}
