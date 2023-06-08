using Clinica.Web.Models;
using System.Linq;

namespace Clinica.Web.Interfaces
{
    public interface ITipoExameRepository
    {
        Task<TipoExame> GetById(int id);

        Task<IEnumerable<TipoExame>> GetAll();

        Task<bool> DeleteTipoExameById(int id);

        Task<bool> UpdateById(TipoExame tipoExame, int id);

        Task<TipoExame> SaveTipoExame(TipoExame tipoExame);
    }
}
