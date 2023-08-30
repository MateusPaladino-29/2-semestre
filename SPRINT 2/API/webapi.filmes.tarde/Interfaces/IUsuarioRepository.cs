using System.CodeDom.Compiler;
using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    public interface IUsuarioRepository
    {
        void Login(string email, UsuarioDomain LoginUsuario);
        UsuarioDomain Login(string email, string senha);
    }
}
