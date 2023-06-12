using Clinica.Web.Models;

namespace Clinica.Web.ViewModels
{
    public class CreateConsultaViewModel
    {
        public Consulta Consulta { get; set; }

        public IEnumerable<Exame> Exames { get; set; }

        public IEnumerable<Paciente> Paciente { get; set;}
    }
}
