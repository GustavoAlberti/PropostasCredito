using CSharpFunctionalExtensions;
using DigitacaoProposta.Comum;
using Microsoft.EntityFrameworkCore;

namespace DigitacaoProposta.Dominio.GravarProposta.Infra
{
    public sealed class PropostasRepositorio(
        GravarPropostaDbContext dbContext)
    {

        //Recupera os dados necessarios para gravar uma proposta valida.
        public async Task<Maybe<Agente>> RecuperarAgente(string cpfAgente)
        {
            return (await dbContext.Agentes.FirstOrDefaultAsync(c => c.CpfAgente == cpfAgente)) ?? Maybe<Agente>.None;
        }

        public async Task<bool> ExistePropostaAberta(string cpfCliente)
        {
            return await dbContext.Propostas
                .AnyAsync(p => p.CpfCliente == cpfCliente && p.Status == StatusProposta.Aberta);
        }

        public async Task<Maybe<Cliente>> RecuperarCliente(string cpf)
        {
            return (await dbContext.Clientes.FirstOrDefaultAsync(c => c.Cpf == cpf)) ?? Maybe<Cliente>.None;
        }

        public async Task<Maybe<Conveniada>> RecuperarConveniada(string nome)
        {
            return (await dbContext.Conveniadas.FirstOrDefaultAsync(c => c.Nome == nome)) ?? Maybe<Conveniada>.None;
        }

        public async Task<Maybe<Estado>> RecuperarEstado(string uf)
        {
            return (await dbContext.Estados.FirstOrDefaultAsync(c => c.Uf == uf)) ?? Maybe<Estado>.None;
        }

        //Adiciona a Proposta
        public async Task Adicionar(Proposta proposta, CancellationToken cancellationToken)
        {
            await dbContext.Propostas.AddAsync(proposta, cancellationToken);
        }

        public Task Save()
        {
            return dbContext.SaveChangesAsync();
        }

    }
}
