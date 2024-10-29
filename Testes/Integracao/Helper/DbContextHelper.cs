using DigitacaoProposta.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Testes.Integracao.Helper
{
    public static class DbContextHelper
    {
        public static GravarPropostaDbContext CriarDbContextEmMemoria()
        {
            var options = new DbContextOptionsBuilder<GravarPropostaDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new GravarPropostaDbContext(options);
            return context;
        }
    }

}
