using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class ConveniadaConfiguration : IEntityTypeConfiguration<Conveniada>
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

            // Seed Data para inserir uma Conveniada
            builder.HasData(new Conveniada(
                id: Guid.Parse("b31c34af-ac07-46b0-ba62-853335ecb140"),  // Esse Guid deve ser o mesmo usado no Agente
                nome: "Conveniada Exemplo",
                aceitaRefinanciamento: true,
                uf: "SP"));

        }
    }
}
