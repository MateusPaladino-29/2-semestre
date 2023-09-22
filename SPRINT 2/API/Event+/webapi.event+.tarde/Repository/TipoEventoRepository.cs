using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repository
{
    public class TipoEventoRepository : ITipoEventoRepository
    {
            private readonly EventContext ctx;

            public TipoEventoRepository()
            {
                ctx = new EventContext();
            }

        public void Atualizar(Guid Id, TipoEvento tipoevento)
        {
            TipoEvento TipoEventoBuscado = ctx.TipoEvento.Find(Id)!;

            if (TipoEventoBuscado != null)
            {
                TipoEventoBuscado.Titulo = tipoevento.Titulo;
            }

             ctx.Update(TipoEventoBuscado);

            ctx.SaveChanges();
        }

        public TipoEvento BuscarPorId(Guid Id)
        {
            TipoEvento TipoEventoBuscado = ctx.TipoEvento.Find(Id)!;

            if (TipoEventoBuscado != null)
            {
               return ctx.TipoEvento.FirstOrDefault(x => x.IdTipoEvento == Id)!;
            }

            return null;
        }

        public void Cadastrar(TipoEvento tipoevento)
        {
            try
            {
                ctx.TipoEvento.Add(tipoevento);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar a rota");
            }
        }

        public void Deletar(Guid Id)
        {
            TipoEvento TipoEventoBuscado = ctx.TipoEvento.Find(Id)!;

            if (TipoEventoBuscado != null)
            {
                ctx.TipoEvento.Remove(TipoEventoBuscado);
            }

            ctx.SaveChanges() ;
        }

        public List<TipoEvento> Listar()
        {
          return ctx.TipoEvento.ToList();
        }
    }
}
