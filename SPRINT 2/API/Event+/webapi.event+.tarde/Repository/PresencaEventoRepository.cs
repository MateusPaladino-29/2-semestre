using webapi.event_.tarde.Context;
using webapi.event_.tarde.Domains;
using webapi.event_.tarde.Interfaces;

namespace webapi.event_.tarde.Repository
{
    public class PresencaEventoRepository : IPresencaEventoRepository
    {
        private readonly EventContext ctx;

        public PresencaEventoRepository()
        {
            ctx = new EventContext();
        }

        public void Atualizar(Guid id, PresencaEvento presencaEvento)
        {
            PresencaEvento BuscarPresenca = ctx.PresencaEvento.Find(id)!;
            if (BuscarPresenca != null)
            {
                BuscarPresenca.Situacao = presencaEvento.Situacao;
            }
        }

        public PresencaEvento BuscarPorId(Guid id)
        {
            PresencaEvento BuscarPresenca = ctx.PresencaEvento.Find(id)!;
            if (BuscarPresenca != null)
            {
                return ctx.PresencaEvento.FirstOrDefault(b => b.IdPresencaEvento == id)!;
            }

            return null!;

        }

        public void Deletar(Guid id)
        {
           PresencaEvento BuscarPresenca = ctx.PresencaEvento.Find(id)!;
            if (BuscarPresenca != null)
            {
                ctx.PresencaEvento.Remove(BuscarPresenca);
            }
        }

        public void Inscrever(PresencaEvento inscricao)
        {
            try
            {
                ctx.PresencaEvento.Add(inscricao);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar rota");
            }
        }

        public List<PresencaEvento> Listar()
        {
          return ctx.PresencaEvento.ToList();
        }

        public List<PresencaEvento> ListarMinhas(Guid id)
        {
            return ctx.PresencaEvento.Where(l => l.IdUsuario == id).ToList();
        }
    }
}
