using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Estado : Entity<Guid>
    {
        public string Nome { get; }
        public string Uf { get; }
        public string Ddd { get; }
        public decimal RestricaoDeValor { get; }
        public bool RequerAssinaturaHibrida { get; }

        private Estado() { }

        public Estado(Guid id, string nome, string uf, string ddd, decimal restricaoDeValor, bool requerAssinaturaHibrida)
        {
            Id = id;
            Nome = nome;
            Uf = uf.ToUpper();
            Ddd = ddd.ToUpper();
            RestricaoDeValor = restricaoDeValor;
            RequerAssinaturaHibrida = requerAssinaturaHibrida;
        }

        // Método para verificar se o valor está dentro da restrição de valor para o estado
        public bool VerificarRestricaoDeValor(decimal valor)
        {
            return valor <= RestricaoDeValor;
        }
    }

}
