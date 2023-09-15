using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email),IsUnique=true)]
    public class UsuarioDomain
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Email é obrogatório!")]
        [EmailAddress(ErrorMessage = "endereço de Email, invalido")]
        public string? Email { get; set; }

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Senha é obrogatório!")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Senha deve conter de 4 a 20 caracteres ")]
        public string? Senha { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuarioDomain? TipoUsuario { get; set; }
    }
}
