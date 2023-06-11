using Clinica.Web.Interfaces;
using Clinica.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Web.Controllers
{
    public class TipoExameController : Controller
    {


        private readonly ITipoExameRepository _repository;

        public TipoExameController(ITipoExameRepository repository) 
        {
            _repository = repository;
        }

        public async Task<ActionResult> Index() 
        {
            var tipoexame = await _repository.GetAll();

            return View(tipoexame);
        }

        [HttpGet]
        public IActionResult Create() 
        {
        
            return View();
        
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind("Id,NomeTipoExame,Descricao")] TipoExame tipoexame) 
        {
        
            await _repository.SaveTipoExame(tipoexame);

            return  RedirectToAction("Index");
        
        
        }


    }
}
