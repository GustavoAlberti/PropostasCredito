using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Conveniada : Entity<Guid>
    {
        public string Nome { get; }
        public bool AceitaRefinanciamento { get; }
        public string Uf { get; } 


        private Conveniada() { }

        public Conveniada(Guid id, string nome, bool aceitaRefinanciamento,string uf)
        {
            Id = id;
            Nome = nome;
            AceitaRefinanciamento = aceitaRefinanciamento;
            Uf = uf.ToUpper();
        }

        
        public bool VerificarRestricaoPorEstado(decimal valorEmprestimo)
        {
            // Regras de restrição baseadas no estado (UF). Aqui, você pode adicionar qualquer lógica necessária.
            if (Uf == "RS" && valorEmprestimo > 50000) // Exemplo: no RS, limite de R$ 50.000,00
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
