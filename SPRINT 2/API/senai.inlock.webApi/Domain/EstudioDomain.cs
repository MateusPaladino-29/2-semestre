using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domain
{
    public class estudioDomain
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Nome { get; set; }
    }
}
