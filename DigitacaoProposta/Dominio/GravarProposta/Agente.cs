using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Agente : Entity<Guid>
    {
        public string Nome { get; }
        public string CpfAgente { get; }
        public StatusAgente Status { get; }
        public string Uf {  get; } //podemos remover.

        private Agente() { }

        public Agente(Guid id, string nome, string cpfAgente, StatusAgente status, string uf)
        {
            Id = id;
            Nome = nome;
            CpfAgente = cpfAgente;
            Status = status;
            Uf = uf;
        }
    }

    public enum StatusAgente
    {
        Ativo,
        Inativo
    }

}
