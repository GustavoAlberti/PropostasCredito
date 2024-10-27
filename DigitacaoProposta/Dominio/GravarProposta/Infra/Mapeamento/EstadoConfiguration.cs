using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("ESTADOS");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Uf)
                   .IsRequired()
                   .HasMaxLength(2)
                   .IsFixedLength()
                   .HasConversion(uf => uf.ToUpper(), uf => uf);

            builder.Property(e => e.Ddd)
                .IsRequired()
                .HasMaxLength(2);

        //public bool RequerAssinaturaHibrida { get; }

            builder.Property(e => e.RestricaoDeValor)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(e => e.RequerAssinaturaHibrida);

            // Seed Data para Estados com restrições de valor
            builder.HasData(
                new Estado(Guid.NewGuid(), "Rio Grande do Sul", "RS", "51", 50000.00m, true),
                new Estado(Guid.NewGuid(), "São Paulo", "SP", "11", 100000.00m, false),
                new Estado(Guid.NewGuid(), "Minas Gerais", "MG", "31", 75000.00m, false),
                new Estado(Guid.NewGuid(), "Rio de Janeiro", "RJ", "21", 85000.00m, true)
            );

        }
    }
}
