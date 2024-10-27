namespace DigitacaoProposta.Dominio.GravarProposta.Aplicacao.DTO
{
    using System.ComponentModel.DataAnnotations;

    public record PropostaInputModel(
        [Required(ErrorMessage = "O CPF do agente é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF do agente deve ter 11 dígitos.")]
        string CpfAgente,

        [Required(ErrorMessage = "O CPF do cliente é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF do cliente deve ter 11 dígitos.")]
        string CpfCliente,

        [Required(ErrorMessage = "O valor do empréstimo é obrigatório.")]
        [Range(1, double.MaxValue, ErrorMessage = "O valor do empréstimo deve ser maior que zero.")]
        decimal ValorEmprestimo,

        [Required(ErrorMessage = "O número de parcelas é obrigatório.")]
        [Range(1, 120, ErrorMessage = "O número de parcelas deve estar entre 1 e 120.")]
        int NumeroParcelas,

        bool Refinanciamento,

        [Required(ErrorMessage = "A conveniada é obrigatória.")]
        string CodigoConveniada

    );

}
