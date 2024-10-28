using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Conveniada : Entity<Guid>
    {
        public string Nome { get; }
        public string Codigo { get; }
        public bool AceitaRefinanciamento { get; }
        public string Uf { get; } 



        private Conveniada() { }

        public Conveniada(Guid id, string nome, string codigo, bool aceitaRefinanciamento,string uf)
        {
            Id = id;
            Nome = nome;
            Codigo = codigo;
            AceitaRefinanciamento = aceitaRefinanciamento;
            Uf = uf.ToUpper();
        }

        //Da pra remover é visto na regra
        public bool VerificarRestricaoPorEstado(decimal valorEmprestimo)
        {
            // Regras de restrição baseadas no estado (UF).
            if (Uf == "RS" && valorEmprestimo > 50000) 
            {
                return false;
            }

            return true; 
        }

        public bool AceitaRefin()
        {
            return AceitaRefinanciamento;
        }
    }

}
