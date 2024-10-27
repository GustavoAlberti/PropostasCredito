using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTES");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.Cpf)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(c => c.DataNascimento)
                   .IsRequired();

            builder.Property(c => c.Sexo)
                   .IsRequired()
                   .HasConversion(new EnumToStringConverter<Sexo>())
                   .HasColumnType("varchar(10)");

            builder.Property(c => c.RendimentoMensal)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.CidadeResidencial)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.UfResidencial)
                   .IsRequired()
                   .HasMaxLength(2);

            builder.Property(c => c.CidadeNaturalidade)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.UfNaturalidade)
                   .IsRequired()
                   .HasMaxLength(2);

            builder.Property(c => c.TelefoneDDD)
                   .IsRequired()
                   .HasMaxLength(2);

            builder.Property(c => c.Telefone)
                   .IsRequired()
                   .HasMaxLength(15);

            builder.Property(c => c.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.StatusCpf)
                   .IsRequired()
                   .HasConversion(new EnumToStringConverter<StatusCpf>()) 
                   .HasColumnType("varchar(20)");

            // Seed Data para inserir um Cliente Ativo
            builder.HasData(new Cliente(
                id: Guid.NewGuid(),
                nome: "João Silva",
                cpf: "12345678901",
                dataNascimento: new DateTime(1980, 5, 20),
                rendimentoMensal: 3500.00m,
                cidadeResidencial: "São Paulo",
                ufResidencial: "SP",
                cidadeNaturalidade: "Campinas",
                ufNaturalidade: "SP",
                telefoneDDD: "11",
                telefone: "987654321",
                email: "joao.silva@example.com",
                sexo: Sexo.Masculino,
                statusCpf: StatusCpf.Liberado)     
           );
        }
    }
}
