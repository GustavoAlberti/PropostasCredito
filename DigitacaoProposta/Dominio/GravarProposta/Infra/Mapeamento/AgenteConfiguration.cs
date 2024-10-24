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

            builder.Property(a => a.Status)
                   .IsRequired()
                   .HasConversion(new EnumToStringConverter<StatusAgente>())
                   .HasColumnName("varchar(20)");

            builder.HasOne<Conveniada>()
                   .WithMany()
                   .HasForeignKey(a => a.ConveniadaId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
