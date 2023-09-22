using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface IComentarioRepository
    {
       
            void Cadastrar(ComentarioEvento comentarioEvento);
            void Deletar(Guid id);
            List<ComentarioEvento> Listar();
            ComentarioEvento BuscarPorId(Guid id);
        
    }
}
