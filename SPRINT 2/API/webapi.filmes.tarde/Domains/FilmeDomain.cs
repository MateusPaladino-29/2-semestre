using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    public class FilmeDomain 
    {
        public int IdFIlme { get; set; }

        [Required(ErrorMessage = "O titlulo do filme é Obrigatorio")]
        public string? Titulo { get; set; }
        public int IdGenero { get; set; }


        //Referencia para a classe genero
        public GeneroDomain? Genero { get; set; }

    }
}
