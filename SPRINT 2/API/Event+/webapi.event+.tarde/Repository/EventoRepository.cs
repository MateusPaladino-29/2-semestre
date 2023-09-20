using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repository
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext ctx;

        public EventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid Id, Evento evento)
        {
            Evento EventoBuscado = ctx.Evento.Find(Id)!;

            if (EventoBuscado != null)
            {
                EventoBuscado.Descricao = evento.Descricao;
                EventoBuscado.DataEvento = evento.DataEvento;
                EventoBuscado.NomeEvento = evento.NomeEvento;
            }

            ctx.SaveChanges();
        }

        public Evento BuscarPorId(Guid Id)
        {
            Evento EventoBuscado = ctx.Evento.Find(Id)!;

            if (EventoBuscado != null)
            {
                return ctx.Evento.FirstOrDefault(e => e.IdEvento == Id)!;
            }
            return null!;
        }

        public void Cadastrar(Evento evento)
        {
            try
            {
                ctx.Evento.Add(evento);

                ctx.SaveChanges()
;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar a rota");
            }
        }

        public void Deletar(Guid Id)
        {
            Evento EventoBuscado = ctx.Evento.Find(Id)!;

            if (EventoBuscado != null)
            {
                ctx.Evento.Remove(EventoBuscado);
            }

            ctx.SaveChanges();

        }

        public List<Evento> Listar()
        {
            return ctx.Evento.ToList();
        }
    }
}
