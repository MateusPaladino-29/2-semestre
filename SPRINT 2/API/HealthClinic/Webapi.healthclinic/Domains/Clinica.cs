using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.healthclinic.Domains
{
    [Table(nameof(Clinica))]
    public class Clinica
    {
        [Key]
        public Guid IdClinica { get; set; } = Guid.NewGuid();

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Obrigatorio ter sua Nome Fantasia ")]
        public string? NomeFantasia  { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Obrigatorio ter sua Razao Social")]
        public string? RazaoSocial { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required(ErrorMessage = "Obrigatorio ter sua Especialidade")]
        public string? Titulo { get; set; }


        [Column(TypeName = "Char(15)")]
        [Required(ErrorMessage = "Obrigatorio ter CNPJ")]
        public int CNPJ { get; set; }

        [Column(TypeName = "Time")]
        [Required(ErrorMessage = "Obrigatorio ter seu horario de Funcionamento")]
        public DateTime HorarioAbertura { get; set; }

        [Column(TypeName = "Time")]
        [Required(ErrorMessage = "Obrigatorio ter seu horario de Funcionamento")]
        public DateTime HorarioFechamento { get; set; }


    }
}
