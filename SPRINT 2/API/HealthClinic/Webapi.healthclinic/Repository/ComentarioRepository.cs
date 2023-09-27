using Webapi.healthclinic.Context;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Repository
{
    public class ComentarioRepository : IComentario
    {
        private readonly HealthContext ctx;

        public ComentarioRepository()
        {
            ctx = new HealthContext();
        }
        public Comentario BuscarPorId(Guid id)
        {
            Comentario comentario = ctx.Comentario.Find(id)!;

            if (comentario != null)
            {
                return ctx.Comentario.FirstOrDefault(b => b.IdComentario == id)!;
            }

            return comentario!;
        }

        public void Cadastrar(Comentario comentario)
        {
            try
            {
                ctx.Comentario.Add(comentario);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar a rota");
            }
        }

        public void Deletar(Guid id)
        {
            Comentario comentario = ctx.Comentario.Find(id)!;

            if (comentario != null)
            {
                ctx.Comentario.Remove(comentario);
            }

            ctx.SaveChanges();
        }

        public List<Comentario> Listar()
        {
           return ctx.Comentario.ToList();
        }
    }
}
