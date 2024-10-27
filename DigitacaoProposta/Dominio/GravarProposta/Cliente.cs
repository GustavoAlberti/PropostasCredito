using CSharpFunctionalExtensions;

namespace DigitacaoProposta.Dominio.GravarProposta
{
    public sealed class Cliente : Entity<Guid>
    {
        public string Nome { get; }
        public string Cpf { get; }
        public DateTime DataNascimento { get; }
        public decimal RendimentoMensal { get; }
        public string CidadeResidencial { get; }
        public string UfResidencial { get; }
        public string CidadeNaturalidade { get; }
        public string UfNaturalidade { get; }
        public string TelefoneDDD { get; }
        public string Telefone { get; }
        public string Email { get; }
        public Sexo Sexo { get; }
        public StatusCpf StatusCpf { get; }

        
        private Cliente() { }

        public Cliente(Guid id, string nome, string cpf, DateTime dataNascimento, decimal rendimentoMensal, string cidadeResidencial, string ufResidencial, string cidadeNaturalidade, string ufNaturalidade, string telefoneDDD, string telefone, string email, Sexo sexo, StatusCpf statusCpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            RendimentoMensal = rendimentoMensal;
            CidadeResidencial = cidadeResidencial;
            UfResidencial = ufResidencial;
            CidadeNaturalidade = cidadeNaturalidade;
            UfNaturalidade = ufNaturalidade;
            TelefoneDDD = telefoneDDD;
            Telefone = telefone;
            Email = email;
            Sexo = sexo;
            StatusCpf = statusCpf;
        }

        public bool CpfBloqueado()
        {
            return StatusCpf == StatusCpf.Bloqueado;
        }
    }

    public enum StatusCpf
    {
        Liberado,
        Bloqueado
    }

    public enum Sexo
    {
        Masculino,
        Feminino,
        Outro
    }

}
