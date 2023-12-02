using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebConsultorioOdontologico.Models;

namespace WebConsultorioOdontologico.Controllers
{
    [Authorize]
    public class MedicamentosController : Controller
    {
        private readonly LabConsultorioOdontologicoContext _context;

        public MedicamentosController(LabConsultorioOdontologicoContext context)
        {
            _context = context;
        }

        // GET: Medicamentos
        public async Task<IActionResult> Index()
        {
            var labConsultorioOdontologicoContext = _context.Medicamentos.Include(m => m.IdInventarioNavigation).Include(m => m.IdPacienteNavigation);
            return View(await labConsultorioOdontologicoContext.Where(x => x.Estado != -1).ToListAsync());
        }

        // GET: Medicamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos
                .Include(m => m.IdInventarioNavigation)
                .Include(m => m.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // GET: Medicamentos/Create
        public IActionResult Create()
        {
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "Id", "Articulo");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Nombres");
            return View();
        }

        // POST: Medicamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPaciente,IdInventario,Cantidad,Descripcion,Total")] Medicamento medicamento)
        {
            if (!string.IsNullOrEmpty(medicamento.Descripcion))
            {
                medicamento.UsuarioRegistro = User.Identity?.Name;
                medicamento.FechaRegistro = DateTime.Now;
                medicamento.Estado = 1;
                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "Id", "Articulo", medicamento.IdInventario);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Nombres", medicamento.IdPaciente);
            return View(medicamento);
        }

        // GET: Medicamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "Id", "Articulo", medicamento.IdInventario);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Nombres", medicamento.IdPaciente);
            return View(medicamento);
        }

        // POST: Medicamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPaciente,IdInventario,Cantidad,Descripcion,Total,UsuarioRegistro,FechaRegistro,Estado")] Medicamento medicamento)
        {
            if (id != medicamento.Id)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(medicamento.Descripcion))
            {
                try
                {
                    medicamento.UsuarioRegistro = User.Identity?.Name;
                    medicamento.FechaRegistro = DateTime.Now;
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoExists(medicamento.Id))
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
            ViewData["IdInventario"] = new SelectList(_context.Inventarios, "Id", "Articulo", medicamento.IdInventario);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Nombres", medicamento.IdPaciente);
            return View(medicamento);
        }

        // GET: Medicamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos
                .Include(m => m.IdInventarioNavigation)
                .Include(m => m.IdPacienteNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // POST: Medicamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicamentos == null)
            {
                return Problem("Entity set 'LabConsultorioOdontologicoContext.Medicamentos'  is null.");
            }
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento != null)
            {
                medicamento.Estado = -1;
                //_context.Medicamentos.Remove(medicamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoExists(int id)
        {
          return (_context.Medicamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
