using Clinica.Web.Models;

namespace Clinica.Web.Interfaces
{
    public interface IPacienteService
    {

        Task<Paciente> GetById(int id);

        Task<IEnumerable<Paciente>> GetAll();

        Task<bool> DeleteById(int id);

        Task<bool> UpdatePaciente(Paciente paciente, int id);

        Task<Paciente> SavePaciente(Paciente paciente);

    }
}
