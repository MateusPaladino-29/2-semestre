using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "O Email do Usuario é Obrigatorio")]

        public String? Senha { get; set; }

        [Required(ErrorMessage = "Necessario Inserir a senha")]

        public String? Permissao { get; set; }
    }
}
