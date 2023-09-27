using Webapi.healthclinic.Domains;

namespace Webapi.healthclinic.Interface
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid Id);

        Usuario BuscarPorEmailESenha(string Email, string Senha);

        List<Usuario> Listar();

    }
}
