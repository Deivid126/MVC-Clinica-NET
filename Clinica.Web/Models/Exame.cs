using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Web.Models
{
    public class Exame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Node do Exame")]
        [StringLength(100)]
        public string NomeExame { get; set; }
        [Required]
        [Display(Name ="Observações")]
        [StringLength(1000)]
        public string Observacoes { get; set; }
        [Required]
        [Display(Name ="Tipo de Exame")]
        [ForeignKey("TipoExame")]
        public int? TipoExameId { get; set; }

        public TipoExame? TipoExame { get; set; }
    }
}
