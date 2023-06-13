using System.ComponentModel.DataAnnotations;

namespace Clinica.Web.Models
{
    public class TipoExame
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Nome do Tipo de Exame")]
        [StringLength(100)]
        public string NomeTipoExame { get; set; }
        [Required]
        [Display(Name = "Descrição do Exame")]
        [StringLength(256)]
        public string Descricao { get; set; }

        public IEnumerable<Exame> Exames { get; set; }


    }
}
