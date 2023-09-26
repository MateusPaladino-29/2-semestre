using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.healthclinic.Domains
{
    [Table(nameof(TipoUsuario))]
    public class TipoUsuario
    {
        [Key]

        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();


        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Titulo do tipo do Usuario Obrigatorio")]
        public String? Titulo { get; set; }

    }
}
