using Clinica.Web.Data;
using Clinica.Web.Interfaces;
using Clinica.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Web.Repository
{
    public class TipoExameRepository : ITipoExameRepository
    {
        private readonly ApplicationDbContext _context;

        public TipoExameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteTipoExameById(int id)
        {
            var tipoexame = await _context.TiposExames.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (tipoexame != null) 
            {
            
                _context.Remove(tipoexame);
                _context.SaveChanges();
                return true;
            
            }

            return false;
        }

        public async Task<IEnumerable<TipoExame>> GetAll()
        {
            return await _context.TiposExames.ToListAsync();
        }

        public async Task<TipoExame> GetById(int id)
        {
            var tipoexame = await _context.TiposExames.Where(x =>x.Id == id).FirstOrDefaultAsync();

            if (tipoexame != null) 
            {
                return tipoexame;
            }

            return null;
        }

        public async Task<TipoExame> SaveTipoExame(TipoExame tipoExame)
        {
            var tipoexamenew = await _context.TiposExames.AddAsync(tipoExame);
            await _context.SaveChangesAsync();

            return tipoexamenew.Entity;

        }

        public async Task<bool> UpdateById(TipoExame tipoExame, int id)
        {
            var tipoexamebanco = await _context.TiposExames.Where(x =>x.Id == id).FirstOrDefaultAsync();

            if(tipoexamebanco != null) 
            {
            
                tipoexamebanco.Descricao = tipoExame.Descricao;
                tipoExame.NomeTipoExame = tipoExame.NomeTipoExame;
                _context.TiposExames.Update(tipoexamebanco);
                return await _context.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}
