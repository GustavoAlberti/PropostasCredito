using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Estado : Entity<Guid>
    {
        public string Nome { get; }
        public string Uf { get; }
        public decimal RestricaoDeValor { get; } // Valor máximo permitido para operações no estado

        private Estado() { }

        public Estado(Guid id, string nome, string uf, decimal restricaoDeValor)
        {
            Id = id;
            Nome = nome;
            Uf = uf;
            RestricaoDeValor = restricaoDeValor;
        }

        // Método para verificar se o valor está dentro da restrição de valor para o estado
        public bool VerificarRestricaoDeValor(decimal valor)
        {
            return valor <= RestricaoDeValor;
        }
    }

}
