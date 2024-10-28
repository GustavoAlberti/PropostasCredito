using CSharpFunctionalExtensions;
using DigitacaoProposta.Dominio.GravarProposta;

namespace Testes.Unidade.Fakes
{
    public class FakePropostasRepositorio
    {
        public Task<Maybe<Agente>> RecuperarAgente(string cpfAgente)
        {
            var agente = new Agente(Guid.NewGuid(), "Agente Ativo", cpfAgente, StatusAgente.Ativo, "RS");
            return Task.FromResult(Maybe<Agente>.From(agente));
        }

        public Task<Maybe<Cliente>> RecuperarCliente(string cpf)
        {
            var cliente = new Cliente(Guid.NewGuid(), "Maria Silva", cpf, new DateTime(1980, 5, 1), 4000, "São Paulo", "SP", "Campinas", "SP", "11", "987654321", "maria.silva@example.com", Sexo.Feminino, StatusCpf.Liberado);
            return Task.FromResult(Maybe<Cliente>.From(cliente));
        }

        public Task<Maybe<Conveniada>> RecuperarConveniada(string codigoConveniada)
        {
            var conveniada = new Conveniada(Guid.NewGuid(), "INSS", codigoConveniada, aceitaRefinanciamento: true, "SP");
            return Task.FromResult(Maybe<Conveniada>.From(conveniada));
        }

        public Task<Maybe<Estado>> RecuperarEstado(string uf)
        {
            var estado = new Estado(Guid.NewGuid(), "São Paulo", uf, "11", restricaoDeValor: 50000, requerAssinaturaHibrida: false);
            return Task.FromResult(Maybe<Estado>.From(estado));
        }

        public Task<bool> ExistePropostaAberta(string cpfCliente)
        {
            return Task.FromResult(false);
        }

        public Task Adicionar(Proposta proposta, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Save()
        {
            return Task.CompletedTask;
        }
    }


}
