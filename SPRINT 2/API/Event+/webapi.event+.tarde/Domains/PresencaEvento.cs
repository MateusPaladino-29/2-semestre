using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.tarde.Domains
{
    [Table(nameof(PresencaEvento))]
    public class PresencaEvento
    {
        [Key]   

        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Bit")]
        [Required(ErrorMessage = "Obrigatorio responder seu Status")]
        public bool Situacao { get; set; }

        //referencia as tabelas Usuarios e Eventos = FK
        [Required(ErrorMessage = "O Usuario é obrigatorio")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }


        [Required(ErrorMessage = "O nome do evento é necessario")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]

        public Evento? Evento { get; set; }
       
    }
}
