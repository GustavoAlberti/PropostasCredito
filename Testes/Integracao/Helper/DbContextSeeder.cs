using DigitacaoProposta.Dominio;
using DigitacaoProposta.Dominio.GravarProposta;

namespace Testes.Integracao.Helper
{
    public static class DbContextSeeder
    {
        public static void PopularDadosIniciais(GravarPropostaDbContext context)
        {
            context.Agentes.Add(new Agente(Guid.NewGuid(), "Agente Ativo", "03691005063", StatusAgente.Ativo, "RS"));
            context.Clientes.Add(new Cliente(Guid.NewGuid(), "Maria Silva", "19117744091", new DateTime(1980, 5, 1), 4000, "São Paulo", "SP", "Campinas", "SP", "11", "987654321", "maria.silva@example.com", Sexo.Feminino, StatusCpf.Liberado));
            context.Conveniadas.Add(new Conveniada(Guid.NewGuid(), "INSS", "CONV001", aceitaRefinanciamento: true, uf: "SP"));
            context.Estados.Add(new Estado(Guid.NewGuid(), "São Paulo", "SP", "11", restricaoDeValor: 50000, requerAssinaturaHibrida: false));
            context.Estados.Add(new Estado(Guid.NewGuid(), "Rio Grande do Sul", "RS", "51", restricaoDeValor: 30000, requerAssinaturaHibrida: true));

            context.SaveChanges();
        }
    }

}
