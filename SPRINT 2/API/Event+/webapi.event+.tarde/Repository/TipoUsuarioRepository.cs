using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly EventContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid Id, TipoUsuario Usuario)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(Id);

            if (tipoUsuarioBuscado != null)
            {
                tipoUsuarioBuscado.Titulo = Usuario.Titulo ;
            }

            ctx.Update();

            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(Guid Id, TipoUsuario tipoUsuario)
        {
            TipoUsuario TipoUsuarioBuscado = ctx.TipoUsuario.Find(Id)!;

            if (TipoUsuarioBuscado != null)
            {
                return ctx.TipoUsuario.FirstOrDefault(x => x.IdTipoUsuario == Id)!;
            }

            return null;
        }

        public TipoUsuario BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(TipoUsuario TipoUsuario)
        {
            try
            {
                ctx.TipoUsuario.Add(TipoUsuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao Cadastrar");


            }
        }

        public void Deletar(Guid Id)
        {
            TipoUsuario tipoUsuarioBuscado = ctx.TipoUsuario.Find(Id);

            if (tipoUsuarioBuscado != null)
            {
                ctx.TipoUsuario.Remove(tipoUsuarioBuscado);
            }

            ctx.SaveChanges();



        }

        public List<TipoUsuario> Listar()
        {
          return ctx.TipoUsuario.ToList();
        }
    }
}
