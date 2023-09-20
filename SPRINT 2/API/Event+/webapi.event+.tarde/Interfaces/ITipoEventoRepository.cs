using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoEventoRepository
    {
        void Cadastrar(TipoEvento tipoevento);
        void Deletar(Guid Id);
        List<TipoEvento> Listar();
        TipoEvento BuscarPorId(Guid Id);
        void Atualizar(Guid Id, TipoEvento tipoevento);
    }
}
