using System.ComponentModel.DataAnnotations;

namespace Clinica.Web.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [StringLength(100)]
        public string Nome { get; set; }
        [Display(Name = "CPF")]
        public string Cpf { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime? dataNascimento { get; set; }
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public IEnumerable<Consulta> Consultas { get; set; }

    }
}
