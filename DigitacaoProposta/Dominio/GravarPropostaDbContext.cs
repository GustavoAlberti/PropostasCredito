using DigitacaoProposta.Dominio.GravarProposta;
using DigitacaoProposta.Dominio.GravarProposta.Infra.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace DigitacaoProposta.Dominio
{
    public class GravarPropostaDbContext : DbContext
    {
        public GravarPropostaDbContext(DbContextOptions<GravarPropostaDbContext> options) : base(options) { }

        public DbSet<Proposta> Propostas { get; set; }

        public DbSet<Agente> Agentes{ get; set; }

        public DbSet<Cliente> Clientes{ get; set; }

        public DbSet<Conveniada> Conveniadas { get; set; }

        public DbSet<Estado> Estados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgenteConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteConfiguration());
            modelBuilder.ApplyConfiguration(new ConveniadaConfiguration());
            modelBuilder.ApplyConfiguration(new EstadoConfiguration());
            modelBuilder.ApplyConfiguration(new PropostaConfiguration());

        }

    }
}
