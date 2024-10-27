using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Proposta : Entity<Guid>
    {
        public string CpfCliente { get; }
        public decimal ValorEmprestimo { get; }
        public int NumeroParcelas { get; }
        public decimal ValorParcela { get; }
        public DateTime DataPrimeiraParcela { get; }
        public DateTime DataUltimaParcela { get; }
        public Guid AgenteId { get; }
        public Guid ConveniadaId { get; }
        public DateTime DataCriacao { get; }
        public StatusProposta Status { get; private set; }
        public TipoOperacao TipoOperacao { get; }
        public TipoAssinatura TipoAssinatura { get; }

        private Proposta() { }

        private Proposta(Guid id, string cpfCliente, decimal valorEmprestimo, int numeroParcelas, decimal valorParcela, 
            DateTime dataPrimeiraParcela, DateTime dataUltimaParcela, Guid agenteId, Guid conveniadaId, DateTime dataCriacao, TipoOperacao tipoOperacao, TipoAssinatura tipoAssinatura)
        {
            Id = id;
            CpfCliente = cpfCliente;
            ValorEmprestimo = valorEmprestimo;
            NumeroParcelas = numeroParcelas;
            ValorParcela = valorParcela;
            DataPrimeiraParcela = dataPrimeiraParcela;
            DataUltimaParcela = dataUltimaParcela;
            AgenteId = agenteId;
            ConveniadaId = conveniadaId;
            DataCriacao = dataCriacao;
            TipoOperacao = tipoOperacao;
            Status = StatusProposta.Aberta;
            TipoAssinatura = tipoAssinatura;

        }

        public static Result<Proposta> Criar(Guid id, string cpfCliente, decimal valorEmprestimo, int numeroParcelas, decimal valorParcela,
            DateTime dataPrimeiraParcela, DateTime dataUltimaParcela, Guid agenteId, Guid conveniadaId, DateTime dataCriacao, TipoOperacao tipoOperacao, TipoAssinatura tipoAssinatura)
        {
            var proposta = new Proposta(id, cpfCliente, valorEmprestimo, numeroParcelas, valorParcela, dataPrimeiraParcela, dataUltimaParcela, agenteId, conveniadaId, dataCriacao, tipoOperacao, tipoAssinatura);

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
