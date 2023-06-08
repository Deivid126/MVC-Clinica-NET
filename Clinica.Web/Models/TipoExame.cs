using System.ComponentModel.DataAnnotations;

namespace Clinica.Web.Models
{
    public class TipoExame
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string NomeTipoExame { get; set; }
        [StringLength(256)]
        public string Descricao { get; set; }


    }
}
