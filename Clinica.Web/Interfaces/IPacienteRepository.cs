using Clinica.Web.Models;

namespace Clinica.Web.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> GetById(int id);

        Task<bool> GetPacienteByCPF(string cpf);
        Task<IEnumerable<Paciente>> GetAll();

        Task<bool>  DeletePaciente(int id);

        Task<bool> UpdatePaciente(Paciente paciente, int id);

        Task<Paciente> SavePaciente(Paciente paciente);
    }
}
