using Clinica.Web.Data;
using Clinica.Web.Interfaces;
using Clinica.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Web.Repository
{
    public class ExameRepository : IExameRepository
    {
        private readonly ApplicationDbContext _context;

        public ExameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteExame(int id)
        {
            var exame = await _context.Exames.Where(x => x.Id == id).FirstOrDefaultAsync();

            if ( exame != null)
            {
                _context.Exames.Remove(exame);
                return _context.SaveChanges() > 0;
            }

            return false;

         
        }

        public async Task<IEnumerable<Exame>> GetAll()
        {
            var exames = await _context.Exames.ToListAsync();

            return exames;
        }

        public async Task<Exame> GetById(int id)
        {
            var exame = await _context.Exames.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (exame != null) 
            {
                return exame;
            }

            return null;

        }

        public async Task<Exame> SaveExame(Exame exame)
        {
            var examenew = await _context.Exames.AddAsync(exame);
            _context.SaveChanges();
            return examenew.Entity;

        }

        public async Task<Exame> Update(Exame exame, int id)
        {
            var examebanco = await _context.Exames.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (examebanco != null)
            {
                examebanco.NomeExame = exame.NomeExame;
                examebanco.Observacoes = exame.Observacoes;
                examebanco.TipoExameId = exame.TipoExameId;
                _context.Exames.Update(examebanco);
                _context.SaveChanges();

                return examebanco;
            }

            return null;
        }
    }
}
