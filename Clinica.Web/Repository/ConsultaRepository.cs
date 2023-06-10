using Clinica.Web.Data;
using Clinica.Web.Interfaces;
using Clinica.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Web.Repository
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ApplicationDbContext _context;

        public ConsultaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteConsultaById(Guid id)
        {
            var consulta = await _context.Consultas.Where(x => x.Protocolo == id).FirstOrDefaultAsync();

            if (consulta != null) 
            {
            
                _context.Consultas.Remove(consulta);
                _context.SaveChanges();
                return true;
            
            }

            return false;
        }

        public async Task<ICollection<Consulta>> GetAll()
        {
            return await _context.Consultas.ToListAsync();
        }

        public async Task<Consulta> GetConsultaById(Guid id)
        {
            var consulta = await _context.Consultas.Where(x => x.Protocolo == id).FirstOrDefaultAsync();

            if(consulta != null) 
            {
            
                return consulta;
            
            }

            return null;
        }

        public async Task<Consulta> SaveConsulta(Consulta consulta)
        {
            bool result = false;
            var listConsultas = await GetAll();

            foreach(var item in listConsultas) 
            {
                if(item.DataConsulta == consulta.DataConsulta) 
                {
                
                    result = true; 
                    break;
                } 
            }
           
            if(!result) 
            {

                var consultanew = await _context.Consultas.AddAsync(consulta);
                await _context.SaveChangesAsync();

                return consultanew.Entity;
            }

            return null;
            
        }

        public async Task<bool> UpdateById(Consulta consulta, Guid id)
        {
            var consultabanco = await _context.Consultas.Where(x => x.Protocolo == id).FirstOrDefaultAsync();
            if(consultabanco != null) 
            {
               
                consultabanco.DataConsulta = consulta.DataConsulta;
                consultabanco.PacienteId = consulta.PacienteId;
                consultabanco.ExameId = consulta.ExameId;
                _context.Consultas.Update(consultabanco);
                _context.SaveChanges();

                return true;
            
            }

            return false;
        }
    }
}
