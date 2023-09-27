using Webapi.healthclinic.Context;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly HealthContext ctx;

        public MedicoRepository()
        {
            ctx = new HealthContext();
        }


        public Medico BuscarPorId(Guid Id)
        {
            Medico MedBuscado = ctx.Medico.Find(Id)!;
            if (MedBuscado != null)
            {
                return ctx.Medico.FirstOrDefault(b => b.IdMedico == Id)!;
            }

            return MedBuscado!;

        }

        public void Cadastrar(Medico medico)
        {
            try
            {
                ctx.Medico.Add(medico);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar a rota");
            }
        }

        public void Deletar(Guid Id)
        {
            Medico MedicoBuscado = ctx.Medico.Find(Id)!;

            if (MedicoBuscado != null )
            {
                ctx.Medico.Remove(MedicoBuscado);
            }

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medico.ToList();
        }
    }
}
