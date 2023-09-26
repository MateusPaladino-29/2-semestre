using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.healthclinic.Domains
{
    [Table(nameof(Usuario))]    
    public class Usuario
    {
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Nome de usuario é obrigatorio")]
        public string? Nome { get; set; }

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Email é obrigatorio")]
        public string? Email { get; set; }


        [Column(TypeName = "Char(60)")]
        [Required(ErrorMessage = "Senha é obrigatorio")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres ")]
        public string? Senha { get; set; }

        //referencia tabela tipo de usuario =   FK

        [Required(ErrorMessage = "O tipo de usuario é obrigatorio")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
