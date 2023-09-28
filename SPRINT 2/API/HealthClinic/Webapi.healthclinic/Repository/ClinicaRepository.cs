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
                clinica.Titulo = clinicabuscada.Titulo;
                clinica.RazaoSocial = clinicabuscada.RazaoSocial;
                clinica.Funcionamento = clinicabuscada.Funcionamento;
                clinica.NomeFantasia = clinica.NomeFantasia;
               
            }

            ctx.Update(clinica);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(Guid Id)
        {
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
                        Funcionamento = u.Funcionamento,

                    }).FirstOrDefault(u => u.IdClinica == Id)!;
            }

                return clinicabuscada!;
        }

        public void Cadastrar(Clinica cLinica)
        {
            try
            {
                ctx.Clinica.Add(cLinica);
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
