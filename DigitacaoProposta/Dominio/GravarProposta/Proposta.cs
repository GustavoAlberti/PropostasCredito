using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Proposta : Entity<Guid>
    {
        public string CpfCliente { get; }
        public decimal ValorEmprestimo { get; }
        public int NumeroParcelas { get; }
        public decimal ValorParcela {  get; }
        public DateTime DataPrimeiraParcela { get; }
        public DateTime DataUltimaParcela { get; }
        public Guid AgenteId { get; }
        public Guid ConveniadaId { get; }
        public DateTime DataCriacao { get; }
        public StatusProposta Status { get; }
        public TipoOperacao TipoOperacao { get; }
        public TipoAssinatura TipoAssinatura { get; }

        private Proposta() { }

        private Proposta(Guid id, string cpfCliente, decimal valorEmprestimo, int numeroParcelas, 
            Guid agenteId, Guid conveniadaId, TipoOperacao tipoOperacao, TipoAssinatura tipoAssinatura)
        {
            Id = id;
            CpfCliente = cpfCliente;
            ValorEmprestimo = valorEmprestimo;
            NumeroParcelas = numeroParcelas;
            DataCriacao = DateTime.Now;
            ValorParcela = ValorEmprestimo / NumeroParcelas;
            DataPrimeiraParcela = DataCriacao.AddMonths(1);
            DataUltimaParcela = DataPrimeiraParcela.AddMonths(NumeroParcelas - 1);
            AgenteId = agenteId;
            ConveniadaId = conveniadaId;
            TipoOperacao = tipoOperacao;
            Status = StatusProposta.Aberta;
            TipoAssinatura = tipoAssinatura;
        }

        public static Result<Proposta> Criar(Guid id, string cpfCliente, decimal valorEmprestimo, int numeroParcelas,
            Guid agenteId, Guid conveniadaId, TipoOperacao tipoOperacao, TipoAssinatura tipoAssinatura)
        {

            var proposta = new Proposta(id, cpfCliente, valorEmprestimo, numeroParcelas, agenteId, conveniadaId,
                                         tipoOperacao, tipoAssinatura);

            return Result.Success(proposta);
        }
    }

    public enum StatusProposta
    {
        Aberta,
        Aprovada,
        Rejeitada
    }

    public enum TipoOperacao
    {
        Refinanciamento,
        ContratoNovo
    }

    public enum TipoAssinatura
    {
        Eletronica,
        Hibrida,
        Figital
    }

}
