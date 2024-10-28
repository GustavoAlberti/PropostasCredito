using System.ComponentModel.DataAnnotations;

namespace DigitacaoProposta.Dominio.GravarProposta.Aplicacao.InputModel
{
    public record PropostaInputModelCompleta(
    [Required(ErrorMessage = "O CPF do agente é obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF do agente deve ter 11 dígitos.")]
    string CpfAgente,

    [Required(ErrorMessage = "Os dados do cliente são obrigatórios.")]
    DadosBasicosInputModel DadosBasicos,

    [Required(ErrorMessage = "O endereço do cliente é obrigatório.")]
    EnderecoInputModel Endereco,

    [Required(ErrorMessage = "Os telefones do cliente são obrigatórios.")]
    TelefonesInputModel Telefones,

    [Required(ErrorMessage = "Os dados da operação são obrigatórios.")]
    OperacaoInputModel Operacao,

    [Required(ErrorMessage = "Os dados de rendimento do cliente são obrigatórios.")]
    RendimentoInputModel Rendimento
    );

    public record DadosBasicosInputModel(
    [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
    string Nome,

    [Required(ErrorMessage = "O CPF do cliente é obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF do cliente deve ter 11 dígitos.")]
    string CpfCliente,

    [Required(ErrorMessage = "A data de nascimento do cliente é obrigatória.")]
    DateTime DataNascimento,

    [Required(ErrorMessage = "O sexo do cliente é obrigatório.")]
    Sexo Sexo,

    [Required(ErrorMessage = "O e-mail do cliente é obrigatório.")]
    [EmailAddress(ErrorMessage = "O e-mail fornecido é inválido.")]
    string Email
    );

    public record EnderecoInputModel(
    [Required(ErrorMessage = "A cidade residencial é obrigatória.")]
    string CidadeResidencial,

    [Required(ErrorMessage = "A UF residencial é obrigatória.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF residencial deve ter 2 caracteres.")]
    string UfResidencial,

    [Required(ErrorMessage = "A cidade de naturalidade é obrigatória.")]
    string CidadeNaturalidade,

    [Required(ErrorMessage = "A UF de naturalidade é obrigatória.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF de naturalidade deve ter 2 caracteres.")]
    string UfNaturalidade
    );

    public record TelefonesInputModel(
    [Required(ErrorMessage = "O DDD do telefone é obrigatório.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "O DDD do telefone deve ter 2 dígitos.")]
    string TelefoneDDD,

    [Required(ErrorMessage = "O número do telefone é obrigatório.")]
    [StringLength(15, ErrorMessage = "O número do telefone deve ter no máximo 15 dígitos.")]
    string Telefone
    );

    public record OperacaoInputModel(
    [Required(ErrorMessage = "O código da conveniada é obrigatório.")]
    string CodigoConveniada,

    [Required(ErrorMessage = "O número de parcelas é obrigatório.")]
    [Range(1, 120, ErrorMessage = "O número de parcelas deve estar entre 1 e 120.")]
    int NumeroParcelas,

    [Required(ErrorMessage = "O valor do empréstimo é obrigatório.")]
    [Range(1, double.MaxValue, ErrorMessage = "O valor do empréstimo deve ser maior que zero.")]
    decimal ValorEmprestimo,

    bool Refinanciamento
    );

    public record RendimentoInputModel(
    [Required(ErrorMessage = "O rendimento mensal é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O rendimento mensal deve ser maior que zero.")]
    decimal RendimentoMensal
    );
}
