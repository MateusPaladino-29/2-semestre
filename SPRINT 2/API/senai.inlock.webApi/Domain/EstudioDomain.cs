using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domain
{
    public class estudioDomain
    {
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public string? Nome { get; set; }

        public int IdEstudio { get; set; }
    }
}
