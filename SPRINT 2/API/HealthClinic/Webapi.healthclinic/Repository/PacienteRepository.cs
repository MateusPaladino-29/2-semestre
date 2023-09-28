using Webapi.healthclinic.Context;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Repository
{

    public class PacienteRepository : IPacienteRepository
    {
        private readonly HealthContext ctx;

        public PacienteRepository()
        {
            ctx = new HealthContext();
        }


        public void Atualizar(Guid Id, Paciente paciente)
        {
            Paciente Pacientebscd = ctx.Paciente.Find(Id)!;
            if (Pacientebscd != null)
            {
                paciente.Idade = Pacientebscd.Idade;
            }

            ctx.Update(paciente);
            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(Guid Id)
        {
            Paciente Pacientebscd = ctx.Paciente.Find(Id)!;
            if (Pacientebscd != null)
            {
                return ctx.Paciente
                      .Select(u => new Paciente
                      {
                          IdPaciente = u.IdPaciente,
                          CPF = u.CPF,
                          Idade = u.Idade,

                          Usuario = new Usuario
                          {
                              IdUsuario = u.IdUsuario,
                              Nome = u.Usuario.Nome,

                          }

                      }).FirstOrDefault(b => b.IdPaciente == Id)!;
            }

            return Pacientebscd!;
        }

        public void Cadastrar(Paciente paciente)
        {
            try
            {
                ctx.Paciente.Add(paciente);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao encontrar a rota");
            }
        }

        public void Deletar(Guid Id)
        {
           Paciente PacienteBuscado = ctx.Paciente.Find(Id)!;
            if (PacienteBuscado != null)
            {
                ctx.Paciente.Remove(PacienteBuscado);
            }

            ctx.SaveChanges();
        }

        public List<Paciente> Listar()
        {
            return ctx.Paciente.ToList();
        }
    }
}
