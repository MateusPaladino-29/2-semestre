using System.ComponentModel.DataAnnotations;

namespace Webapi.healthclinic.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha é Obrigatorio")]
        public string? Senha { get; set; }
    }
}
