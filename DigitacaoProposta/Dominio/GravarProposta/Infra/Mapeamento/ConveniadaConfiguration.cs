using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class ConveniadaConfiguration : IEntityTypeConfiguration<Conveniada>
    {
        public void Configure(EntityTypeBuilder<Conveniada> builder)
        {
            builder.ToTable("CONVENIADAS");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Codigo)
                    .IsRequired()
                    .HasMaxLength(10);

            builder.Property(c => c.AceitaRefinanciamento)
                   .IsRequired();
            
            builder.Property(c => c.Uf)
                   .IsRequired()
                   .HasMaxLength(2)
                   .IsFixedLength() 
                   .HasConversion(uf => uf.ToUpper(), uf => uf);

            // Seed Data para inserir uma Conveniada
            builder.HasData(
                new Conveniada(id: Guid.Parse("b31c34af-ac07-46b0-ba62-853335ecb140"), nome: "INSS", codigo: "CONV001", aceitaRefinanciamento: true, uf: "SP"),
                new Conveniada(id: Guid.Parse("0b9bfb95-b9af-41de-9b02-fc301ba33302"), nome: "SIAPE", codigo: "CONV002", aceitaRefinanciamento: true, uf: "SP"),
                new Conveniada(id: Guid.Parse("ed8081c8-5aa6-41ef-a5c2-9b405cc989f8"), nome: "MARINHA", codigo: "CONV003", aceitaRefinanciamento: false, uf: "SP")
                );

        }
    }
}
