using Clinica.Web.Interfaces;
using Clinica.Web.Models;
using Clinica.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Web.Controllers
{
    public class ExameController : Controller
    {
        private readonly IExameRepository _repository;
        private readonly ITipoExameRepository tipoexamerepository;

        public ExameController(IExameRepository repository, ITipoExameRepository tipoExame) 
        {
            tipoexamerepository = tipoExame;
            _repository = repository;
        
        }
        [HttpGet]
        public async Task<ActionResult> Index() 
        {
        
            var view = await _repository.GetAll();

            return View(view);
        
        }

        public async Task<IActionResult> Create() 
        {
            var tiposexames = await tipoexamerepository.GetAll();

            var viewModel = new CreateExameViewModel
            {
                TipoExame = tiposexames
            };

            return View(viewModel);


        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id) 
        {
        
            var exame = await _repository.GetById(id);
            var tiposexames = await tipoexamerepository.GetAll();

            var viewModel = new CreateExameViewModel
            {
                TipoExame = tiposexames,
                Exame = exame
            };

            return View(viewModel);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,NomeExame,Observacoes,TipoExameId")] Exame exame) 
        {

            await _repository.Update(exame, id);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind("Id,NomeExame,Observacoes,TipoExameId")] Exame exame) 
        {

            await _repository.SaveExame(exame);

            return RedirectToAction("Index");
            

                    
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id) 
        {
        
        
            await _repository.DeleteExame(id);
            return RedirectToAction("Index");
        
        }





    }
}
