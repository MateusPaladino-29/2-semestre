using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);
        void Deletar(Guid Id);
        List<Evento> Listar();
        Evento BuscarPorId(Guid Id);
        void Atualizar(Guid Id, Evento evento);
    }
}
