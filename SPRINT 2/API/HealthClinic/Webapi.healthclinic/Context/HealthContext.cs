using Microsoft.EntityFrameworkCore;
using Webapi.healthclinic.Domains;

namespace Webapi.healthclinic.Context
{
    public class HealthContext : DbContext
    {
        public DbSet<Paciente> Paciente { get; set; }
          public DbSet<Medico> Medico { get; set; }
          public DbSet<Agendamento> Agendamento { get; set; }
          public DbSet<Clinica> Clinica { get; set; }
          public DbSet<Comentario> Comentario { get; set; }
          public DbSet<Especialidade> Especialidade { get; set; }
          public DbSet<TipoUsuario> TipoUsuario { get; set; }
          public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE05-S14; Database=health_clinic_API; User Id = sa; pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }
        



    }
}
