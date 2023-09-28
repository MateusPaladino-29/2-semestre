using Webapi.healthclinic.Domains;

namespace Webapi.healthclinic.Interface
{
    public interface IAgendamentoRepository
    {
        void Cadastrar(Agendamento agendamento);
        void Deletar(Guid Id);
        List<Agendamento> Listar();
        Agendamento BuscarPorId(Guid Id);
        void Atualizar(Guid Id, Agendamento agendamento);
    }
}
