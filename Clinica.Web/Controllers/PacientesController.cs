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

namespace Clinica.Web.Controllers
{
    public class PacientesController : Controller
    {
        private readonly IPacienteService _service;

        public PacientesController(IPacienteService service)
        {
            _service = service;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
           var pacientes = await _service.GetAll();

            if(pacientes != null) 
            {
            
                return View(pacientes);
            
            }

            return View(null);
        }

        // GET: Pacientes/Details/5
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
            return NotFound();
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return NotFound();
        }

       
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,dataNascimento,Sexo,Telefone,Email")] Paciente paciente)
        {
            return NotFound();
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return NotFound();
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return NotFound();

        }
    }
}
