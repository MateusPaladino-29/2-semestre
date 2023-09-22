

using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repository
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly EventContext ctx;

        public ComentarioRepository()
        {
            ctx = new EventContext();
        }

        public ComentarioEvento BuscarPorId(Guid id)
        {
            ComentarioEvento ComentarioBuscado = ctx.ComentarioEvento.Find(id)!;

            if (ComentarioBuscado != null)
            {
                ctx.ComentarioEvento.FirstOrDefault(b => b.IdComentarioEvento == id);

                return ComentarioBuscado;
            }

            return null!;

        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                ctx.ComentarioEvento.Add(comentarioEvento);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar a rota");
            }
        }

        public void Deletar(Guid id)
        {
           ComentarioEvento ComentarioBuscado = ctx.ComentarioEvento.Find(id)!;

            if (ComentarioBuscado != null)
            {
                ctx.ComentarioEvento.Remove(ComentarioBuscado);
            }

            ctx.SaveChanges();
        }

        public List<ComentarioEvento> Listar()
        {
            return ctx.ComentarioEvento.ToList();
        }
    }
}
