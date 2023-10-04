using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Webapi.healthclinic.Domains
{
    [Table(nameof(Medico))]
    public class Medico
    {
        [Key]

        public Guid IdMedico { get; set; } = Guid.NewGuid();

        [Column(TypeName = "char(6)")]
        [Required(ErrorMessage = "CRM é obrigatorio")]
        public string? CRM  { get; set; }

        //referencia tabela usuario =   FK

        [Required(ErrorMessage = "O usuario é obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Especialidade é Obrigatorio ")]
        public Guid IdEspecialidade { get; set; }

        [ForeignKey(nameof(IdEspecialidade))]
        public Especialidade? Especialidade { get; set; }

        [Required(ErrorMessage = "Clinica é Obrigatorio")]
        public Guid IdClinica { get; set; }

        [ForeignKey(nameof(IdClinica))]
        public  Clinica? Clinica { get; set; }




    }
}
