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
    public class InventariosController : Controller
    {
        private readonly LabConsultorioOdontologicoContext _context;

        public InventariosController(LabConsultorioOdontologicoContext context)
        {
            _context = context;
        }

        // GET: Inventarios
        public async Task<IActionResult> Index()
        {
              return _context.Inventarios != null ? 
                          View(await _context.Inventarios.Where(x => x.Estado != -1).ToListAsync()) :
                          Problem("Entity set 'LabConsultorioOdontologicoContext.Inventarios'  is null.");
        }

        // GET: Inventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Inventarios == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // GET: Inventarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Articulo,Precio")] Inventario inventario)
        {
            if (!string.IsNullOrEmpty(inventario.Articulo))
            {
                inventario.UsuarioRegistro = User.Identity?.Name;
                inventario.FechaRegistro = DateTime.Now;
                inventario.Estado = 1;
                _context.Add(inventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventario);
        }

        // GET: Inventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Inventarios == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            return View(inventario);
        }

        // POST: Inventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Articulo,Precio,UsuarioRegistro,FechaRegistro,Estado")] Inventario inventario)
        {
            if (id != inventario.Id)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(inventario.Articulo))
            {
                try
                {
                    inventario.UsuarioRegistro = User.Identity?.Name;
                    inventario.FechaRegistro = DateTime.Now;
                    _context.Update(inventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioExists(inventario.Id))
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
            return View(inventario);
        }

        // GET: Inventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Inventarios == null)
            {
                return NotFound();
            }

            var inventario = await _context.Inventarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inventario == null)
            {
                return NotFound();
            }

            return View(inventario);
        }

        // POST: Inventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Inventarios == null)
            {
                return Problem("Entity set 'LabConsultorioOdontologicoContext.Inventarios'  is null.");
            }
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario != null)
            {
                inventario.Estado = -1;
                inventario.UsuarioRegistro = User.Identity?.Name;
                //_context.Inventarios.Remove(inventario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioExists(int id)
        {
          return (_context.Inventarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
