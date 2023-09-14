using webapi.inlock_codefirst.Contexts;
using webapi.inlock_codefirst.Domains;
using webapi.inlock_codefirst.Interfaces;
using webapi.inlock_codefirst.Utils;

namespace webapi.inlock_codefirst.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Variavel privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

       /// <summary>
       /// Construtor do repostorio 
       /// Tod vez que o repositorio for instanciado 
       /// Ele tera acesso aos dados fornecido pelo contexto
       /// </summary>
        public UsuarioRepository()
        { 
           
            ctx = new InlockContext();
        }
        public UsuarioDomain BUscarUsuario(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(UsuarioDomain Usuario)
        {
            try
            {
                Usuario.Senha = Criptografia.GerarHash(Usuario.Senha!);

                ctx.Add(Usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Cadastrar");
            }

        }
    }
}
