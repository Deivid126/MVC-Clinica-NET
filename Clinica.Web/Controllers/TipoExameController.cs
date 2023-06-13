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
        [HttpGet]
        public async Task<ActionResult> Delete(int id) 
        {
            
            await _repository.DeleteTipoExameById(id);

            return RedirectToAction("Index");
        
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {

           var tipoexame =  await _repository.GetById(id);

            return View(tipoexame);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,NomeTipoExame,Descricao")] TipoExame tipoexame) 
        {


            await _repository.UpdateById(tipoexame, id);
            return RedirectToAction("Index");
        
        
        }





    }
}
