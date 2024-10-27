using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class PropostaConfiguration : IEntityTypeConfiguration<Proposta>
    {
        public void Configure(EntityTypeBuilder<Proposta> builder)
        {
            builder.ToTable("PROPOSTAS");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.CpfCliente)
                   .IsRequired()
                   .HasMaxLength(11);

            builder.Property(p => p.ValorEmprestimo)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.NumeroParcelas)
                   .IsRequired();

            builder.Property(p => p.ValorParcela)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.DataPrimeiraParcela)
                   .IsRequired();

            builder.Property(p => p.DataUltimaParcela)
                   .IsRequired();

            builder.HasOne<Agente>() 
                   .WithMany()
                   .HasForeignKey(p => p.AgenteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<Conveniada>() 
                   .WithMany()           
                   .HasForeignKey(p => p.ConveniadaId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.DataCriacao)
                   .IsRequired();

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasConversion(new EnumToStringConverter<StatusProposta>())
                   .HasColumnType("varchar(20)");

            builder.Property(p => p.TipoOperacao)
                   .IsRequired()
                   .HasConversion(new EnumToStringConverter<TipoOperacao>())
                   .HasColumnType("varchar(20)");

            builder.Property(p => p.TipoAssinatura)
                   .IsRequired()
                   .HasConversion(new EnumToStringConverter<TipoAssinatura>())
                   .HasColumnType("varchar(20)");

        }
    }
}
