using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento
{
    public class ConveniadaConfigurationcs : IEntityTypeConfiguration<Conveniada>
    {
        public void Configure(EntityTypeBuilder<Conveniada> builder)
        {
            builder.ToTable("Conveniadas");

            builder.HasKey(i => i.Id);




        }
    }
}
