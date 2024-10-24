using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Agente : Entity<Guid>
    {
        public string Nome { get; }
        public StatusAgente Status { get; }
        public Guid ConveniadaId { get; }

        private Agente() { }

        public Agente(Guid id, string nome, StatusAgente status, Guid conveniadaId)
        {
            Id = id;
            Nome = nome;
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
