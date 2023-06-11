using Clinica.Web.Models;

namespace Clinica.Web.ViewModels
{
    public class CreateExameModel
    {
        public Exame Exame { get; set; }
        public IEnumerable<TipoExame> TipoExame { get; set;}
    }
}
