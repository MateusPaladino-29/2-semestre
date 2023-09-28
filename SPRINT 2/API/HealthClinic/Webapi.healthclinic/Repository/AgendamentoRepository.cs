using Webapi.healthclinic.Context;
using Webapi.healthclinic.Domains;
using Webapi.healthclinic.Interface;

namespace Webapi.healthclinic.Repository
{
    public class AgendamentoRepository : IAgendamentoRepository
    {
        private readonly HealthContext ctx;

        public AgendamentoRepository()
        {
            ctx = new HealthContext();
        }
        public void Atualizar(Guid id, Agendamento agendamento)
        {
           Agendamento consultaBuscada = ctx.Agendamento.Find(id)!;

            if (consultaBuscada != null)
            {
                consultaBuscada.DataConsulta = agendamento.DataConsulta;
                consultaBuscada.HoraConsulta = agendamento.HoraConsulta;
                consultaBuscada.Prontuario = agendamento.Prontuario;
                consultaBuscada.IdMedico = agendamento.IdMedico;
            }

            ctx.Agendamento.Update(consultaBuscada!);
            ctx.SaveChanges();
        }

        public void Atualizar(Guid Id, Clinica clinica)
        {
            throw new NotImplementedException();
        }

        public Agendamento BuscarPorId(Guid id)
        {
            try
            {
                Agendamento consultaBuscada = ctx.Agendamento
                    .Select(u => new Agendamento
                    {
                        IdAgendamento = u.IdAgendamento,
                        DataConsulta = u.DataConsulta,
                        HoraConsulta = u.HoraConsulta,
                        Prontuario = u.Prontuario,

                        Medico = new Medico
                        {
                            IdMedico = u.IdMedico,
                        },
                        Paciente = new Paciente
                        {
                            IdPaciente = u.IdPaciente,
                        }
                    }).FirstOrDefault(u => u.IdAgendamento == id)!;

                return consultaBuscada;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Agendamento agendamento)
        {
            try
            {
                ctx.Agendamento.Add(agendamento);

                ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    
        public void Deletar(Guid id)
        {
            Agendamento consultaBuscada = ctx.Agendamento.Find(id)!;

            if (consultaBuscada != null)
            {
                ctx.Agendamento.Remove(consultaBuscada);
            }

            ctx.SaveChanges();
        }

        public List<Agendamento> Listar()
        {
            return ctx.Agendamento.ToList();
        }
    }
}

