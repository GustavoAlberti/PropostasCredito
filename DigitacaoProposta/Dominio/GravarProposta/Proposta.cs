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
        public StatusProposta Status { get; private set; } // Enum para status da proposta
        public TipoOperacao TipoOperacao { get; }

        private Proposta() { }

        // Construtor privado que inicializa a proposta
        private Proposta(Guid id, string cpfCliente, decimal valorEmprestimo, int numeroParcelas, decimal valorParcela, DateTime dataPrimeiraParcela, Guid agenteId, Guid conveniadaId, DateTime dataCriacao, TipoOperacao tipoOperacao)
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
            Status = StatusProposta.Aberta; // Proposta é criada com status "Aberta"
        }

        //Ajustar conforme modelagem de handler
        public static Result<Proposta> Criar(Guid id, string cpfCliente, decimal valorEmprestimo, int numeroParcelas, decimal valorParcela, DateTime dataPrimeiraParcela, Guid agenteId, Guid conveniadaId, DateTime dataCriacao, TipoOperacao tipoOperacao)
        {
            // Inicialmente, sem regras de validação
            
            var proposta = new Proposta(Guid.NewGuid(), cpfCliente, valorEmprestimo, numeroParcelas, valorParcela, dataPrimeiraParcela, agenteId, conveniadaId, dataCriacao, tipoOperacao);

            return Result.Success(proposta);
        }

        // Método para aprovar a proposta
        public void Aprovar()
        {
            if (Status != StatusProposta.Aberta)
            {
                throw new InvalidOperationException("A proposta não pode ser aprovada, pois não está no status correto.");
            }

            Status = StatusProposta.Aprovada;
        }

        // Método para rejeitar a proposta
        public void Rejeitar()
        {
            if (Status != StatusProposta.Aberta)
            {
                throw new InvalidOperationException("A proposta não pode ser rejeitada, pois não está no status correto.");
            }

            Status = StatusProposta.Rejeitada;
        }
    }

    // Enum para status da proposta
    public enum StatusProposta
    {
        Aberta,
        Aprovada,
        Rejeitada
    }

    // Enum para tipo de operação
    public enum TipoOperacao
    {
        Refinanciamento,
        Emprestimo
    }

}
