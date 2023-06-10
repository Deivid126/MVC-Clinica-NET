using Clinica.Web.Interfaces;
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



    }
}
