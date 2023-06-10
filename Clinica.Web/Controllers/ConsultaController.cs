using Clinica.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Web.Controllers
{
    public class ConsultaController : Controller
    {

        private readonly IConsultaRepository _repository;

        public ConsultaController(IConsultaRepository repository)
        {
            _repository = repository;
        }   


        public async Task<ActionResult> Index() 
        { 
        
            var consultas = await _repository.GetAll();

            return View(consultas);
        
        }
    }
}
