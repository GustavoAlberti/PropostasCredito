using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class AgenteConfiguration : IEntityTypeConfiguration<Agente>
    {
        public void Configure(EntityTypeBuilder<Agente> builder)
        {
            builder.ToTable("Agentes");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(c => c.CpfAgente)
                  .IsRequired()
                  .HasMaxLength(11);

            builder.Property(a => a.Status)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<StatusAgente>())
                .HasColumnType("varchar(20)");

            builder.HasOne<Conveniada>()
                   .WithMany()
                   .HasForeignKey(a => a.ConveniadaId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Seed Data para inserir um Agente Ativo
            builder.HasData(new Agente(
                id: Guid.NewGuid(),
                nome: "Agente Ativo",
                cpfAgente: "12345678901",
                status: StatusAgente.Ativo,
                conveniadaId: Guid.Parse("b31c34af-ac07-46b0-ba62-853335ecb140"))); // Use o ID da conveniada correspondente
        }
    }
}
