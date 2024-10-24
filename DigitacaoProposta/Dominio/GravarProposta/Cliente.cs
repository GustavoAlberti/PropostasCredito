using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Cliente : Entity<Guid>
    {
        public string Nome { get; }
        public string Cpf { get; }
        public DateTime DataNascimento { get; }
        public decimal RendimentoMensal { get; }
        public string Cidade { get; }
        public string Uf { get; } // Estado (Unidade Federativa)
        public string Telefone { get; }
        public string Email { get; }
        public StatusCpf StatusCpf { get; } // Enum para status do CPF (liberado/bloqueado)

        
        private Cliente() { }

        public Cliente(Guid id, string nome, string cpf, DateTime dataNascimento, decimal rendimentoMensal, string cidade, string uf, string telefone, string email, StatusCpf statusCpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            RendimentoMensal = rendimentoMensal;
            Cidade = cidade;
            Uf = uf;
            Telefone = telefone;
            Email = email;
            StatusCpf = statusCpf;
        }


        public int CalcularIdade()
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - DataNascimento.Year;
            if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }

        public bool CpfBloqueado()
        {
            return StatusCpf == StatusCpf.Bloqueado;
        }
    }

    // Enum para o status do CPF
    public enum StatusCpf
    {
        Liberado,
        Bloqueado
    }

}
