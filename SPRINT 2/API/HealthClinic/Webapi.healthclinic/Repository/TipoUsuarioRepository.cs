using Webapi.healthclinic.Context;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Repository
{

    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private readonly HealthContext ctx;

        public TipoUsuarioRepository()
        {
            ctx = new HealthContext();
        }
        public void Atualizar(Guid Id, TipoUsuario Usuario)
        {
            TipoUsuario TipoBuscado = ctx.TipoUsuario.Find(Id)!;

            if (TipoBuscado != null)
            {
                TipoBuscado.Titulo = Usuario.Titulo;
            }

            ctx.Update(Usuario);
            ctx.SaveChanges();
        }

        TipoUsuario BuscarPorId(Guid Id)
        {
            TipoUsuario TipoBuscado = ctx.TipoUsuario.Find(Id)!;

            if (TipoBuscado != null)
            {
               return ctx.TipoUsuario.FirstOrDefault(b => b.IdTipoUsuario == Id)!;
            }

            return TipoBuscado!;
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

                throw new Exception("Erro ao encontrar a rota");
            }
        }

        public void Deletar(Guid Id)
        {
                TipoUsuario TipoBuscado = ctx.TipoUsuario.Find(Id)!;

            if (TipoBuscado != null)
            {
                ctx.TipoUsuario.Remove(TipoBuscado);
            }

            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuario.ToList();
        }

        TipoUsuario ITipoUsuarioRepository.BuscarPorId(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
