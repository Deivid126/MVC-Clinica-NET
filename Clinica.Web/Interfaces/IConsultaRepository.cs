using Clinica.Web.Models;

namespace Clinica.Web.Interfaces
{
    public interface IConsultaRepository
    {

        Task<Consulta> GetConsultaById(Guid id);

        Task<IEnumerable<Consulta>> GetAll();

        Task<bool> DeleteConsultaById(Guid id);

        Task<bool> UpdateById(Consulta consulta, Guid id);

        Task<Consulta> SaveConsulta(Consulta consulta);
    }
}
