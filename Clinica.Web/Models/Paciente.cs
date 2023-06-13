using Clinica.Web.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace Clinica.Web.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Required]
        [Display(Name = "Data de Nascimento")]
        public DateTime? dataNascimento { get; set; }
        [Required]
        [Display(Name = "Sexo")]
        public Sexo Sexo { get; set; }
        [Required]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public IEnumerable<Consulta> Consultas { get; set; }

    }
}
