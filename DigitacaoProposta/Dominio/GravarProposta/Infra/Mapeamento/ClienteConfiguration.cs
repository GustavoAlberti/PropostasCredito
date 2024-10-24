using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(c => c.Cpf)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(c => c.DataNascimento)
                   .IsRequired();

            builder.Property(c => c.RendimentoMensal)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Cidade)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Uf)
                   .IsRequired()
                   .HasMaxLength(2); // Exemplo: "SP", "RJ", etc.

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
        }
    }
}
