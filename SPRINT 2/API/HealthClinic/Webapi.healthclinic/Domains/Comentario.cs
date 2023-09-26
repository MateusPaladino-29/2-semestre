using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Webapi.healthclinic.Domains
{
    [Table(nameof(Comentario))]
    public class Comentario
    {
        [Key]

        public Guid IdComentario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Varchar(100)")]
        public string Descricao { get; set; }

        [Column(TypeName = "Bit")]
        public bool Exibe { get; set;}
    }
}
