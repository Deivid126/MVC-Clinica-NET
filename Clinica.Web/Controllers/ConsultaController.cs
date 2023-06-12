using Clinica.Web.Interfaces;
using Clinica.Web.Models;
using Clinica.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Clinica.Web.Controllers
{
    public class ConsultaController : Controller
    {

        private readonly IConsultaRepository _repository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IExameRepository _examerepository;

        public ConsultaController(IConsultaRepository repository, IPacienteRepository paciente, IExameRepository exame)
        {
            _repository = repository;
            _pacienteRepository = paciente;
            _examerepository = exame;
        }   


        public async Task<ActionResult> Index() 
        { 
        
            var consultas = await _repository.GetAll();

            return View(consultas);
        
        }

        public async Task<IActionResult> Create() 
        {
        
            var pacientes = await _pacienteRepository.GetAll();
            var exames = await _examerepository.GetAll();

            var viewmodel = new CreateConsultaViewModel
            {

                Paciente = pacientes,
                Exames = exames

            };

            return View(viewmodel);
        
        
        }
        [HttpGet]
        public async Task<IActionResult> BuscaDinamica(string termoPesquisa)
        {

            var pacientes = await _pacienteRepository.GetByNameOrCPF(termoPesquisa);

            
            return Json(pacientes);
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,DataConsulta,ExameId,PacienteId")] Consulta consulta) 
        {
        
           var result =   await _repository.SaveConsulta(consulta);

            if( result != null) 
            {

                return RedirectToAction("Index");

            }

            ModelState.AddModelError("", "Já existe uma Consulta com essa Data e Hora");

            var pacientes = await _pacienteRepository.GetAll();
            var exames = await _examerepository.GetAll();

            var viewmodel = new CreateConsultaViewModel
            {

                Paciente = pacientes,
                Exames = exames

            };

            return View(viewmodel);

        }
    }
}
