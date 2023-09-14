using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock_codefirst.Domains
{
    [Table("Jogo")]

    public class jogoDomain
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "Varchar(100)")]
        [Required(ErrorMessage = "Nome do jogo obrogatório!")]
        public String? Nome { get; set; }

        [Column(TypeName = "text")]
        [Required(ErrorMessage = "descricao do jogo é obrogatório!")]
        public String Descricao { get; set; }

        [Column(TypeName = "Date")]
        [Required(ErrorMessage = "Data de lançamento do jogo obrogatório!")]
        public DateTime DatLancamento { get; set; }

        [Column(TypeName = "Decimal(8,2)")]
        [Required(ErrorMessage = "Preço do jogo obrogatório!")]
        public Decimal Preco { get; set; }

        //ref.tabela estudio - FK

        public Guid IdEstudio { get; set; }
        [ForeignKey("IdEstudio")]
        public EstudioDomain? Estudio { get; set; }
    }
}
