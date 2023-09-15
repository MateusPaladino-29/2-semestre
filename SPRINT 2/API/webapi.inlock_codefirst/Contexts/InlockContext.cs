using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using webapi.inlock_codefirst.Domains;


namespace webapi.inlock_codefirst.Contexts
{
    public class InlockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<EstudioDomain> Estudio { get; set; }

        public DbSet<jogoDomain> Jogo { get; set; }

        public DbSet<TipoUsuarioDomain> TIposUsuarios { get; set; }

        public DbSet<UsuarioDomain> Usuario { get; set; }

        //Define as opcoes da construção do banco

        //Amanhã nao esquecer de subir para meu proprio banco
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE05-S14; Database=inlock_games_codefirst_tarde; User Id = sa; pwd = Senai@134; TrustServerCertificate=True;");
            base.OnConfiguring(optionsBuilder);
        }




    }
}
