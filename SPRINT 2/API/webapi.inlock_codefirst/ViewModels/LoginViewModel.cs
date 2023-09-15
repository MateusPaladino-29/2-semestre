using System.ComponentModel.DataAnnotations;

namespace webapi.inlock_codefirst.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email é obrigatorio")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha ë Obrigatorio")]
        public string? Senha { get; set; }
    }
}
