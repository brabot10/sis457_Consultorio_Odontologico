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
    public class UsuariosController : Controller
    {
        private readonly LabConsultorioOdontologicoContext _context;

        public UsuariosController(LabConsultorioOdontologicoContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var labConsultorioOdontologicoContext = _context.Usuarios.Include(u => u.IdPersonalNavigation);
            return View(await labConsultorioOdontologicoContext.Where(x => x.Estado != -1).ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            var personalFiltrados = _context.Personals.Where(x => x.Estado != -1).ToList();
            ViewData["IdPersonal"] = new SelectList(personalFiltrados, "Id", "Nombres");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPersonal,Usuario1")] Usuario usuario)
        {
            if (!string.IsNullOrEmpty(usuario.Usuario1))
            {
                usuario.Clave = Util.Encrypt("dental");
                usuario.UsuarioRegistro = User.Identity?.Name; 
                usuario.FechaRegistro = DateTime.Now;
                usuario.Estado = 1;
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var personalFiltrados = _context.Personals.Where(x => x.Estado != -1).ToList();
            ViewData["IdPersonal"] = new SelectList(personalFiltrados, "Id", "Nombres", usuario.IdPersonal);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            var personalFiltrados = _context.Personals.Where(x => x.Estado != -1).ToList();
            ViewData["IdPersonal"] = new SelectList(personalFiltrados, "Id", "Nombres", usuario.IdPersonal);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPersonal,Usuario1,Clave,UsuarioRegistro,FechaRegistro,Estado")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(usuario.Usuario1))
            {
                try
                {
                    usuario.Clave = Util.Encrypt("dental");
                    usuario.UsuarioRegistro = User.Identity?.Name;
                    usuario.FechaRegistro = DateTime.Now;
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
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
            ViewData["IdPersonal"] = new SelectList(personalFiltrados, "Id", "Nombres", usuario.IdPersonal);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'LabConsultorioOdontologicoContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                usuario.Estado = -1;
                usuario.UsuarioRegistro = User.Identity?.Name;
                //_context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
