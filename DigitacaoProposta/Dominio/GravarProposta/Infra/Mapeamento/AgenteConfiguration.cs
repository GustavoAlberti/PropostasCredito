using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class AgenteConfiguration : IEntityTypeConfiguration<Agente>
    {
        public void Configure(EntityTypeBuilder<Agente> builder)
        {
            builder.ToTable("AGENTES");

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

            builder.Property(a => a.Uf)
                   .IsRequired()
                   .HasMaxLength(2)
                   .IsFixedLength()
                   .HasConversion(uf => uf.ToUpper(), uf => uf);

            // Seed Data para inserir um Agente Ativo
            builder.HasData(
                new Agente(id: Guid.NewGuid(), nome: "Marcio Junior", cpfAgente: "12345678901",status: StatusAgente.Ativo, uf: "SP"),
                new Agente(id: Guid.NewGuid(), nome: "Maria Rita", cpfAgente: "32165498701", status: StatusAgente.Ativo, uf: "SP"),
                new Agente(id: Guid.NewGuid(), nome: "Joao Pedro", cpfAgente: "02635418097", status: StatusAgente.Ativo, uf: "RS")
                );
        }
    }
}
