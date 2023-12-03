using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebConsultorioOdontologico.Models;

namespace WebConsultorioOdontologico.Controllers
{
    [Authorize]
    public class PacientesController : Controller
    {
        private readonly LabConsultorioOdontologicoContext _context;

        public PacientesController(LabConsultorioOdontologicoContext context)
        {
            _context = context;
        }

        // GET: Pacientes
        public async Task<IActionResult> Index()
        {
            var labConsultorioOdontologicoContext = _context.Pacientes.Include(p => p.IdPersonalNavigation);
            return View(await labConsultorioOdontologicoContext.Where(x => x.Estado != -1).ToListAsync());
        }

        // GET: Pacientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // GET: Pacientes/Create
        public IActionResult Create()
        {
            var personalFiltrados = _context.Personals.Where(x => x.Estado != -1).ToList();
            ViewData["IdPersonal"] = new SelectList(personalFiltrados, "Id", "Nombres");
            //ViewData["IdPersonal"] = new SelectList(_context.Personals, "Id", "Nombres");
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPersonal,Nombres,CedulaIdentidad,Alergias,FechaNacimiento,Celular")] Paciente paciente)
        {
            var personalFiltrados = _context.Personals.Where(x => x.Estado != -1).ToList();
            if (!string.IsNullOrEmpty(paciente.Nombres))
            {
                if (!Regex.IsMatch(paciente.Nombres, "^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ()\\s]+$"))
                {
                    ModelState.AddModelError(nameof(paciente.Nombres), "El campo Nombres solo puede contener letras");
                }
                if (paciente.Alergias != null)
                {
                    if (!Regex.IsMatch(paciente.Alergias, "^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ()\\s]+$"))
                    {
                        ModelState.AddModelError(nameof(paciente.Alergias), "El campo Alergias solo puede contener letras");
                    }
                }

                if (!Regex.IsMatch(paciente.Celular.ToString(), "^\\d+$"))
                {
                    ModelState.AddModelError(nameof(paciente.Celular), "El campo Celular debe contener solo números");
                }

                // Verifica si ya existe un paciente con el mismo carné de identidad
                var pacienteExistente = await _context.Pacientes
                    .FirstOrDefaultAsync(x => x.CedulaIdentidad == paciente.CedulaIdentidad && x.Estado != -1);

                if (pacienteExistente != null)
                {
                    ModelState.AddModelError("CedulaIdentidad", "Ya existe un paciente con el mismo cédula  de identidad.");
                    ViewData["IdPersonal"] = new SelectList(personalFiltrados, "Id", "Nombres", paciente.IdPersonal);
                    return View(paciente);
                }


                paciente.UsuarioRegistro = User.Identity?.Name;
                paciente.FechaRegistro = DateTime.Now;
                paciente.Estado = 1;
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["IdPersonal"] = new SelectList(personalFiltrados, "Id", "Nombres", paciente.IdPersonal);
            //ViewData["IdPersonal"] = new SelectList(_context.Personals, "Id", "Nombres", paciente.IdPersonal);
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            var personalFiltrados = _context.Personals.Where(x => x.Estado != -1).ToList();
            ViewData["IdPersonal"] = new SelectList(personalFiltrados, "Id", "Nombres", paciente.IdPersonal);
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPersonal,Nombres,CedulaIdentidad,Alergias,FechaNacimiento,Celular,UsuarioRegistro,FechaRegistro,Estado")] Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(paciente.Nombres))
            {
                try
                {
                    paciente.UsuarioRegistro = User.Identity?.Name;
                    paciente.FechaRegistro = DateTime.Now;
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var personalFiltrados = _context.Personals.Where(x => x.Estado != -1).ToList();
            ViewData["IdPersonal"] = new SelectList(personalFiltrados, "Id", "Nombres", paciente.IdPersonal);
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes
                .Include(p => p.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacientes == null)
            {
                return Problem("Entity set 'LabConsultorioOdontologicoContext.Pacientes'  is null.");
            }
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                paciente.Estado = -1;
                paciente.UsuarioRegistro = User.Identity?.Name;
                //_context.Pacientes.Remove(paciente);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return (_context.Pacientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
