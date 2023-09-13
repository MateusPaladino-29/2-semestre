using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("TiposUsuarios")]
    public class TipoUsuarioDomain
    {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Titulo é obrogatório!")]
        public string? Titulo { get; set; }
    }
}
