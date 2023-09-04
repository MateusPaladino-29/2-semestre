using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O Email do Usuario é Obrigatorio")]
        public string? Email { get; set; }


        [StringLength(20,MinimumLength = 4, ErrorMessage = "O campo Senha ë necessario") ]
        [Required(ErrorMessage = "Necessario Inserir a senha")]
        public String? Senha { get; set; }

   

        public String? Permissao { get; set; }
    }
}
