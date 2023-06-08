using Clinica.Web.Models;

namespace Clinica.Web.Interfaces
{
    public interface IExameRepository
    {
        Task<Exame> GetById(int id);

        Task<IEnumerable<Exame>> GetAll();

        Task<Exame> SaveExame(Exame exame);

        Task<bool> DeleteExame(int id);

        Task<Exame> Update(Exame exame, int id);

    }
}
