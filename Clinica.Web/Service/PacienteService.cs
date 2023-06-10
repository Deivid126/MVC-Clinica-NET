using Clinica.Web.Interfaces;
using Clinica.Web.Models;

namespace Clinica.Web.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _repository;


        public PacienteService(IPacienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteById(int id)
        {
            var result = await _repository.DeletePaciente(id);

            return result;
        }

        public async Task<IEnumerable<Paciente>> GetAll()
        {
             return await _repository.GetAll();

         

        }

        public async Task<Paciente> GetById(int id)
        {
            var paciente = await _repository.GetById(id);

            if ( paciente == null) 
            {

                return null;
            
            }

            return paciente;
        }

        public async Task<Paciente> SavePaciente(Paciente paciente)
        {
            var pacienteexiste = await _repository.GetPacienteByCPF(paciente.Cpf);

            if (pacienteexiste) 
            {

                await _repository.SavePaciente(paciente);
            
            }

            return null;
        }

        public async Task<bool> UpdatePaciente(Paciente paciente, int id)
        {
            var pacienteexiste = await _repository.GetById(id);

            if(pacienteexiste != null)
            {
                await _repository.UpdatePaciente(paciente, id);
                return true;
            }

            return false;


        }
    }
}
