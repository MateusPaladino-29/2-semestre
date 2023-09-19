using System.ComponentModel.DataAnnotations;

namespace webapi.event_.tarde.ViewModels
{
    public class LoginViewModel
    {
      
        
            [Required(ErrorMessage = "Email é obrigatorio")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Senha é Obrigatorio")]
            public string? Senha { get; set; }
        
    }
}
