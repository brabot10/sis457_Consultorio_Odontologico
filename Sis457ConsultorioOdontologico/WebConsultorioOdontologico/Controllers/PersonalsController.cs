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
    public class PersonalsController : Controller
    {
        private readonly LabConsultorioOdontologicoContext _context;

        public PersonalsController(LabConsultorioOdontologicoContext context)
        {
            _context = context;
        }

        // GET: Personals
        public async Task<IActionResult> Index()
        {
              return _context.Personals != null ? 
                          View(await _context.Personals.Where(x => x.Estado != -1).ToListAsync()) :
                          Problem("Entity set 'LabConsultorioOdontologicoContext.Personals'  is null.");
        }

        // GET: Personals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // GET: Personals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CedulaIdentidad,Nombres,Especialidad,Antiguedad,Direccion,Celular,Cargo")] Personal personal)
        {
            if (!string.IsNullOrEmpty(personal.Nombres))
            {
                if (!Regex.IsMatch(personal.Nombres, "^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ()\\s]+$"))
                {
                    ModelState.AddModelError(nameof(personal.Nombres), "El campo Nombres solo puede contener letras");
                }
                if (!Regex.IsMatch(personal.Celular.ToString(), "^\\d+$"))
                {
                    ModelState.AddModelError(nameof(personal.Celular), "El campo Celular debe contener solo números");
                }
                var pacienteExistente = await _context.Personals
                    .FirstOrDefaultAsync(x => x.CedulaIdentidad == personal.CedulaIdentidad && x.Estado != -1);

                if (pacienteExistente != null)
                {
                    ModelState.AddModelError("CedulaIdentidad", "Ya existe un personal con la mismo cédula  de identidad.");
                    return View(personal);
                }
                personal.UsuarioRegistro = User.Identity?.Name;
                personal.FechaRegistro = DateTime.Now;
                personal.Estado = 1;
                _context.Add(personal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personal);
        }

        // GET: Personals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals.FindAsync(id);
            if (personal == null)
            {
                return NotFound();
            }
            return View(personal);
        }

        // POST: Personals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CedulaIdentidad,Nombres,Especialidad,Antiguedad,Direccion,Celular,Cargo,UsuarioRegistro,FechaRegistro,Estado")] Personal personal)
        {
            if (id != personal.Id)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(personal.Nombres))
            {
                try
                {
                    personal.UsuarioRegistro = User.Identity?.Name;
                    personal.FechaRegistro = DateTime.Now;
                    _context.Update(personal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonalExists(personal.Id))
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
            return View(personal);
        }

        // GET: Personals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personals == null)
            {
                return NotFound();
            }

            var personal = await _context.Personals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personal == null)
            {
                return NotFound();
            }

            return View(personal);
        }

        // POST: Personals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Personals == null)
            {
                return Problem("Entity set 'LabConsultorioOdontologicoContext.Personals'  is null.");
            }
            var personal = await _context.Personals.FindAsync(id);
            if (personal != null)
            {
                personal.Estado = -1;
                personal.UsuarioRegistro = User.Identity?.Name;
                //_context.Personals.Remove(personal);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonalExists(int id)
        {
          return (_context.Personals?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
