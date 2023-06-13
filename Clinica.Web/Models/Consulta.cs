using Clinica.Web.Helpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinica.Web.Models
{
    public class Consulta
    {
        [Key]
        public Guid Protocolo { get; set; }

        [Required]
        [Display(Name ="Paciente")]
        [ForeignKey("Paciente")]
        public int? PacienteId { get; set; }

        public Paciente? Paciente { get; set; }
        [Required]
        [Display(Name = "Exame")]
        [ForeignKey("Exame")]
        public int? ExameId { get; set; }

        public Exame? Exame { get; set; }
        [Required]
        [Display(Name ="Data e Hora da Consulta")]
        [CustomDateValidation(ErrorMessage = "A data da consulta não pode estar no passado.")]
        public DateTime? DataConsulta { get; set; }




    }
}
