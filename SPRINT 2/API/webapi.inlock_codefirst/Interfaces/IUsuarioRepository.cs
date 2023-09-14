using webapi.inlock_codefirst.Domains;

namespace webapi.inlock_codefirst.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain BUscarUsuario(string email, string senha);

        void Cadastrar(UsuarioDomain Usuario);
    }
}