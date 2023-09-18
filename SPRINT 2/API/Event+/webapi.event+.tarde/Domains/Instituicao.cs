using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
    {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();


        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Nome Fantasia Obrigatorio")] 
        public String? NomeFantasia { get; set; }


        [Column(TypeName = "Char(14)")]
        [Required(ErrorMessage = "CNPJ Obrigatorio")]
        [StringLength(14)]
        public String? CNPJ { get; set; }


        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Endereço Obrigatorio")]
        public String? Endereco { get; set; }
    }
}
