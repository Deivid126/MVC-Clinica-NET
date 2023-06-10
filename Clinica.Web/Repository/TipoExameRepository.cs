using Clinica.Web.Interfaces;
using Clinica.Web.Models;

namespace Clinica.Web.Repository
{
    public class TipoExameRepository : ITipoExameRepository
    {
        public Task<bool> DeleteTipoExameById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TipoExame>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<TipoExame> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TipoExame> SaveTipoExame(TipoExame tipoExame)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateById(TipoExame tipoExame, int id)
        {
            throw new NotImplementedException();
        }
    }
}
