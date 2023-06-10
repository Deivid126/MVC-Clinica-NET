using Clinica.Web.Interfaces;
using Clinica.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Web.Controllers
{
    public class ExameController : Controller
    {
        private readonly IExameRepository _repository;

        public ExameController(IExameRepository repository) 
        {
        
            _repository = repository;
        
        }
        [HttpGet]
        public async Task<ActionResult> Index() 
        {
        
            var view = await _repository.GetAll();

            return View(view);
        
        }

        [HttpPost]
        public async Task<ActionResult> Create(Exame consulta) 
        {

            return null;
                    
        }





    }
}
