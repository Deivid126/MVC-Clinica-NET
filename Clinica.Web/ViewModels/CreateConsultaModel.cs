using Clinica.Web.Models;

namespace Clinica.Web.ViewModels
{
    public class CreateConsultaModel
    {
        public Consulta Consulta { get; set; }

        public IEnumerable<Exame> Exames { get; set; }

        public ICollection<Paciente> Paciente { get; set;}
    }
}
