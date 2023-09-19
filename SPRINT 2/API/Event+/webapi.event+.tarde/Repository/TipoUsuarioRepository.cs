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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<TipoUsuario> Listar()
        {
          return ctx.TipoUsuario.ToList();
        }
    }
}
