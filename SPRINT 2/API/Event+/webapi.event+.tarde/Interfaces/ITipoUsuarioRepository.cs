using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        void Cadastrar(TipoUsuario TipoUsuario);
        void Deletar(Guid Id);
        List<TipoUsuario> Listar();
        TipoUsuario BuscarPorId(Guid Id);
        void Atualizar(Guid Id, TipoUsuario Usuario);
    }
}
