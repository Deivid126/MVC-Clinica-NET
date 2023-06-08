using System.ComponentModel.DataAnnotations;

namespace Clinica.Web.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime? dataNascimento { get; set; }

        public string Sexo { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public IEnumerable<Consulta> Consultas { get; set; }

    }
}
