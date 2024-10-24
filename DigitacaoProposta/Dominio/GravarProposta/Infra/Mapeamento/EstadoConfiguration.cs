using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("Estados");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Uf)
                   .IsRequired()
                   .HasMaxLength(2)
                   .IsFixedLength()
                   .HasConversion(uf => uf.ToUpper(), uf => uf);

            builder.Property(e => e.RestricaoDeValor)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

        }
    }
}
