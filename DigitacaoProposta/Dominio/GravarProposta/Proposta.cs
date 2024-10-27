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
        public Guid AgenteId { get; }
        public Guid ConveniadaId { get; }
        public DateTime DataCriacao { get; }
        public StatusProposta Status { get; private set; }
        public TipoOperacao TipoOperacao { get; }
        public TipoAssinatura TipoAssinatura { get; }

        private Proposta() { }

        // Construtor privado que inicializa a proposta
        private Proposta(Guid id, string cpfCliente, decimal valorEmprestimo, int numeroParcelas, decimal valorParcela, 
            DateTime dataPrimeiraParcela, Guid agenteId, Guid conveniadaId, DateTime dataCriacao, TipoOperacao tipoOperacao, TipoAssinatura tipoAssinatura)
        {
            Id = id;
            CpfCliente = cpfCliente;
            ValorEmprestimo = valorEmprestimo;
            NumeroParcelas = numeroParcelas;
            ValorParcela = valorParcela;
            DataPrimeiraParcela = dataPrimeiraParcela;
            AgenteId = agenteId;
            ConveniadaId = conveniadaId;
            DataCriacao = dataCriacao;
            TipoOperacao = tipoOperacao;
            Status = StatusProposta.Aberta;
            TipoAssinatura = tipoAssinatura;
        }

        public static Result<Proposta> Criar(Guid id, string cpfCliente, decimal valorEmprestimo, int numeroParcelas, decimal valorParcela, 
            DateTime dataPrimeiraParcela, Guid agenteId, Guid conveniadaId, DateTime dataCriacao, TipoOperacao tipoOperacao, TipoAssinatura tipoAssinatura)
        {
            // Inicialmente, sem regras de validação
            
            var proposta = new Proposta(id, cpfCliente, valorEmprestimo, numeroParcelas, valorParcela, dataPrimeiraParcela, agenteId, conveniadaId, dataCriacao, tipoOperacao, tipoAssinatura);

            return Result.Success(proposta);
        }

        public void Aprovar()
        {
            if (Status != StatusProposta.Aberta)
            {
                throw new InvalidOperationException("A proposta não pode ser aprovada, pois não está no status correto.");
            }

            Status = StatusProposta.Aprovada;
        }

        public void Rejeitar()
        {
            if (Status != StatusProposta.Aberta)
            {
                throw new InvalidOperationException("A proposta não pode ser rejeitada, pois não está no status correto.");
            }

            Status = StatusProposta.Rejeitada;
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
