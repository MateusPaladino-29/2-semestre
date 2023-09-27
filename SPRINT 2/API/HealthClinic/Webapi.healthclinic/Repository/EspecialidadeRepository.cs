using Webapi.healthclinic.Context;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Repository
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        private readonly HealthContext ctx;

        public EspecialidadeRepository()
        {
            ctx = new HealthContext();
        }
        public void Cadastrar(Especialidade especialidade)
        {
            try
            {
                ctx.Especialidade.Add(especialidade);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Rota nao encontrada");
            }
        }

        public void Deletar(Guid Id)
        {
            Especialidade especialidadebusc = ctx.Especialidade.Find(Id)!;

            if (especialidadebusc != null)
            {
                 ctx.Especialidade.Remove(especialidadebusc); 
            }

            ctx.SaveChanges();
        }

        public List<Especialidade> Listar()
        {
            return ctx.Especialidade.ToList();
        }
    }
}
