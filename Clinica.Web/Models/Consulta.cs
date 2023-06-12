using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Web.Models
{
    public class Consulta
    {
        [Key]
        public Guid Protocolo { get; set; }


        [Display(Name ="Paciente")]
        [ForeignKey("Paciente")]
        public int? PacienteId { get; set; }

        public Paciente? Paciente { get; set; }
        [Display(Name = "Exame")]
        [ForeignKey("Exame")]
        public int? ExameId { get; set; }

        public Exame? Exame { get; set; }
        [Display(Name ="Data e Hora da Consulta")]
        public DateTime? DataConsulta { get; set; }




    }
}
