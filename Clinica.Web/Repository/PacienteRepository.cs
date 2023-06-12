using Clinica.Web.Data;
using Clinica.Web.Interfaces;
using Clinica.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Web.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApplicationDbContext _context;

        public PacienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> GetPacienteByCPF(string cpf) 
        {
        
            var paciente = await _context.Pacientes.Where(x => x.Cpf == cpf).FirstOrDefaultAsync();

            if(paciente == null) 
            {
                
                return true;
            
            }

            return false;
        
        }
        public async Task<bool> DeletePaciente(int id)
        {
            var paciente = await _context.Pacientes.Where(x => x.Id == id).FirstOrDefaultAsync();

            if ( paciente != null) 
            {
            
                _context.Pacientes.Remove(paciente);
               return  _context.SaveChanges() > 0;
            
            }

            return false;
        }

        public async Task<IEnumerable<Paciente>> GetAll()
        {
            return await _context.Pacientes.ToListAsync();

        }

        public async Task<Paciente> GetById(int id)
        {
           
            var paciente = await _context.Pacientes.Where(x => x.Id == id).FirstOrDefaultAsync();

            if ( paciente != null) 
            {
            
                return paciente;
            
            }

            return null;
        }

        public async Task<Paciente> SavePaciente(Paciente paciente)
        {
            var pacientenew = await _context.Pacientes.AddAsync(paciente);
            _context.SaveChanges();
            return pacientenew.Entity;
        }

        public async Task<bool> UpdatePaciente(Paciente paciente, int id)
        {
            var pacientebanco = await _context.Pacientes.Where(_ => _.Id == id).FirstOrDefaultAsync();

            if ( pacientebanco != null)
            {
                pacientebanco.Nome = paciente.Nome;
                pacientebanco.Cpf = paciente.Cpf;
                pacientebanco.Telefone = paciente.Telefone;
                pacientebanco.Sexo = paciente.Sexo;
                pacientebanco.Email = paciente.Email;
                pacientebanco.dataNascimento = paciente.dataNascimento;
                _context.Pacientes.Update(pacientebanco);
               return _context.SaveChanges() > 0;

       
            }

            return false;
        }

        public async Task<IEnumerable<Paciente>> GetByNameOrCPF(string termo)
        {
            var resultados = await _context.Pacientes
              .Where(p => p.Nome.Contains(termo) || p.Cpf.Contains(termo))
              .ToListAsync();

            return resultados;
        }
    }
}
