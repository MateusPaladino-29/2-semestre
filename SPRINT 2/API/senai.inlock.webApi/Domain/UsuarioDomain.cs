using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domain
{
    public class UsuarioDomain
    {
        public int IdTipoUsuario { get; set; }

        public int IdUsuario { get; set;}

        [Required(ErrorMessage = "O campo Email é Obrigatório")]
        public string? Email { get; set;}

        [Required(ErrorMessage = "O campo Senha é Obrigatório")]
        public string? Senha { get; set;}

       


    }
}
