using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clinica.Web.Data;
using Clinica.Web.Models;
using Clinica.Web.Interfaces;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Clinica.Web.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteService _service;
        private readonly IPacienteRepository _repository;

        public PacientesController(IPacienteService service, IPacienteRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        // GET: Pacientes
        [HttpGet]
        [Route("Pacientes")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<Paciente> pacientes = await  _service.GetAll();

         
            if (pacientes != null)
            {

                return View(pacientes);

            }


            return View(null);
        }
        [HttpGet]
        public bool IsValidEmail(string email)
        {
            // Expressão regular para validar o e-mail
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Verifica se o e-mail corresponde ao padrão da expressão regular
            return Regex.IsMatch(email, pattern);
        }
        public async Task<IActionResult> Details(int id)
        {
            var paciente = await _service.GetById(id);

            if(paciente != null) 
            {
            
                return View(paciente);
            
            }

            return NotFound();
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,dataNascimento,Sexo,Telefone,Email")] Paciente paciente)
        {
            var pacienteexiste = await _repository.GetPacienteByCPF(paciente.Cpf);


            if (!pacienteexiste) 
            {
                ModelState.AddModelError("", "CPF já está Cadastrado");

            }
            else 
            {
                await _service.SavePaciente(paciente);
                return RedirectToAction("Index");

            }
            
            
           return View();

            

           
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var paciente = await _repository.GetById(id);

            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,dataNascimento,Sexo,Telefone,Email")] Paciente paciente)
        {
            await _repository.UpdatePaciente(paciente, id);
            return RedirectToAction("Index");
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeletePaciente(id);

            return RedirectToAction("Index");

        }

        
    }
}
