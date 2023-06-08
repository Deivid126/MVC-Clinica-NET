using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Web.Models
{
    public class Consulta
    {
        [Key]
        public Guid Protocolo { get; set; }

        [ForeignKey("Paciente")]
        public int? PacienteId { get; set; }

        public Paciente? Paciente { get; set; }

        [ForeignKey("Exame")]
        public int? ExameId { get; set; }

        public Exame? Exame { get; set; }

        public DateTime? DataConsulta { get; set; }




    }
}
