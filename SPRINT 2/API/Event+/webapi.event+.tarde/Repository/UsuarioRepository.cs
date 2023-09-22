using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;
using webapi.event_.tarde.Ultil;

namespace webapi.event_.tarde.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EventContext ctx;

        public UsuarioRepository()
        {
            ctx = new EventContext();
        }


        public Usuario BuscarPorEmailESenha(string Email, string Senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario
                    .Select(u => new Usuario
                    {
                        IdUsuario = u.IdUsuario,
                        Nome = u.Nome,
                        Email = u.Email,
                        Senha = u.Senha,

                        TipoUsuario = new TipoUsuario
                        {
                            IdTipoUsuario = u.IdTipoUsuario,
                            Titulo = u.TipoUsuario!.Titulo
                        }
                    }).FirstOrDefault(u => u.Email == Email)!;

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha!);
               

                if (confere)
                {
                    return usuarioBuscado;
                }

                }

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid Id)
        {
            Usuario usuarioBuscado = ctx.Usuario
                .Select(u => new Usuario
            {
                IdUsuario = u.IdUsuario,
                Nome = u.Nome,
                Email = u.Email,

                TipoUsuario = new TipoUsuario
                {
                    IdTipoUsuario = u.IdTipoUsuario,
                    Titulo = u.TipoUsuario!.Titulo
                }
            }).FirstOrDefault(u => u.IdUsuario == Id)!;
            
            return usuarioBuscado;
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Cadastrar Usuario");
            }
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuario.ToList();
        }
    }
}
