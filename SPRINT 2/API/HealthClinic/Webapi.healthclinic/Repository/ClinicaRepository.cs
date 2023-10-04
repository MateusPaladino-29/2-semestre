using Webapi.healthclinic.Context;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Repository
{
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly HealthContext ctx;

        public ClinicaRepository()
        {
            ctx = new HealthContext();
        }
        public void Atualizar(Guid Id, Clinica clinica)
        {
            Clinica clinicabuscada = ctx.Clinica.Find(Id)!;
            if (clinicabuscada != null)
            {
               
                clinica.RazaoSocial = clinicabuscada.RazaoSocial;
                clinica.HorarioAbertura = clinicabuscada.HorarioAbertura;
                clinica.HorarioFechamento= clinicabuscada.HorarioFechamento;
                clinica.NomeFantasia = clinica.NomeFantasia;
               
            }

            ctx.Update(clinica);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(Guid Id)
        {
          /*  try
            {
                return ctx.Clinica.FirstOrDefault(e => e.IdClinica == Id);
            }
            catch (Exception)
            {

                throw;
            }*/
            Clinica clinicabuscada = ctx.Clinica.Find(Id)!;
            if (clinicabuscada != null)
            {
                Clinica clinicaBuscada = ctx.Clinica

                   .Select(u => new Clinica
                    {
                        IdClinica = u.IdClinica,
                        NomeFantasia = u.NomeFantasia,
                        CNPJ = u.CNPJ,
                        RazaoSocial = u.RazaoSocial,
                        HorarioAbertura = u.HorarioAbertura,
                        HorarioFechamento= u.HorarioFechamento,

                    }).FirstOrDefault(u => u.IdClinica == Id)!;
            }

                return clinicabuscada!;
        }

        public void Cadastrar(Clinica clinica)
        {
            try
            {
                ctx.Clinica.Add(clinica);
                ctx.SaveChanges();  
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar a rota");
            }
        }

        public void Deletar(Guid Id)
        {
            Clinica clinicabuscada = ctx.Clinica.Find(Id)!;
            if (clinicabuscada != null)
            {
                ctx.Clinica.Remove(clinicabuscada);
            }

            ctx.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return ctx.Clinica.ToList();
        }
    }
}
