using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Agente : Entity<Guid>
    {
        public string Nome { get; }
        public string CpfAgente { get; }
        public StatusAgente Status { get; }
        public Guid ConveniadaId { get; }

        private Agente() { }

        public Agente(Guid id, string nome, string cpfAgente, StatusAgente status, Guid conveniadaId)
        {
            Id = id;
            Nome = nome;
            CpfAgente = cpfAgente;
            Status = status;
            ConveniadaId = conveniadaId;
        }
    }

    // Enum para status do agente
    public enum StatusAgente
    {
        Ativo,
        Inativo
    }

}
