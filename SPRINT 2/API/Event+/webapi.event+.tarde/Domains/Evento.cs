using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]

        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "Data é obrigatorio")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Nome é obrigatorio")]
        public String? NomeEvento { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "Descricao é obrigatorio")]
        public String? Descricao { get; set; }

        // Referencia a tabela TipoEventos e IdInstituicao como KF 

        [Required(ErrorMessage = "O tipo de Evento é obrigatorio")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }


        [Required(ErrorMessage = "O nome da instituicao é necessario")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]

        public Instituicao? Instituicao { get; set; }

    }
}
