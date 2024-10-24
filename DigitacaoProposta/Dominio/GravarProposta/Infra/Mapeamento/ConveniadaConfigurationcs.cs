using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class ConveniadaConfigurationcs : IEntityTypeConfiguration<Conveniada>
    {
        public void Configure(EntityTypeBuilder<Conveniada> builder)
        {
            builder.ToTable("Conveniadas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.AceitaRefinanciamento)
                   .IsRequired();

            
            builder.Property(c => c.Uf)
                   .IsRequired()
                   .HasMaxLength(2)
                   .IsFixedLength() 
                   .HasConversion(uf => uf.ToUpper(), uf => uf);

        }
    }
}
