using Webapi.healthclinic.Domains;

namespace Webapi.healthclinic.Interface
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
