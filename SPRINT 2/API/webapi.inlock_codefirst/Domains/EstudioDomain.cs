using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("Estudio")]
    public class EstudioDomain
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Nome obrigatório")]
        public String?  Nome { get; set; }

        public List<jogoDomain>? jogo { get; set; }
    }
}
