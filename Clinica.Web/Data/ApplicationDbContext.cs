using Clinica.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Exame> Exames { get; set; }

        public DbSet<TipoExame> TiposExames { get;set; }

        public DbSet<Paciente> Pacientes { get; set;}
    }
}
