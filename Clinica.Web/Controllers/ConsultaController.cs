using Clinica.Web.Interfaces;
using Clinica.Web.Models;
using Clinica.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

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

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) 
        {

             var consulta = await _repository.GetConsultaById(id);
            var pacientes = await _pacienteRepository.GetAll();
            var exames = await _examerepository.GetAll();

            var viewmodel = new CreateConsultaViewModel
            {

                Paciente = pacientes,
                Exames = exames,
                Consulta = consulta

            };

            return View(viewmodel);
        
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DataConsulta,ExameId,PacienteId")] Consulta consulta)
        {
           var result = await _repository.UpdateById(consulta, id);

            if (result == true)
            {

                return RedirectToAction("Index");

            }


            ModelState.AddModelError("", "Já existe uma Consulta com essa Data e Hora");

            var pacientes = await _pacienteRepository.GetAll();
            var exames = await _examerepository.GetAll();
            var consultabanco = await _repository.GetConsultaById(id);
            var viewmodel = new CreateConsultaViewModel
            {

                Paciente = pacientes,
                Exames = exames,
                Consulta = consultabanco

            };

            return View(viewmodel);
        }
      

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,DataConsulta,ExameId,PacienteId")] Consulta consulta) 
        {
        
           var result =   await _repository.SaveConsulta(consulta);

       
            if ( result != null) 
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

        public async Task<IActionResult> Delete(Guid id) 
        {
            await _repository.DeleteConsultaById(id);

            return RedirectToAction("Index");
        
        }
    }
}
