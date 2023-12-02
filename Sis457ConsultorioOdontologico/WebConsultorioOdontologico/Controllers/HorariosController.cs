﻿using System;
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
    public class HorariosController : Controller
    {
        private readonly LabConsultorioOdontologicoContext _context;

        public HorariosController(LabConsultorioOdontologicoContext context)
        {
            _context = context;
        }

        // GET: Horarios
        public async Task<IActionResult> Index()
        {
            var labConsultorioOdontologicoContext = _context.Horarios.Include(h => h.IdPersonalNavigation);
            return View(await labConsultorioOdontologicoContext.Where(x => x.Estado != -1).ToListAsync());
        }

        // GET: Horarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // GET: Horarios/Create
        public IActionResult Create()
        {
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "Id", "Nombres");
            return View();
        }

        // POST: Horarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPersonal,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Mes,Permiso")] Horario horario)
        {
            if (!string.IsNullOrEmpty(horario.Lunes))
            {
                horario.UsuarioRegistro = User.Identity?.Name;
                horario.FechaRegistro = DateTime.Now;
                horario.Estado = 1;
                _context.Add(horario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "Id", "Nombres", horario.IdPersonal);
            return View(horario);
        }

        // GET: Horarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null)
            {
                return NotFound();
            }
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "Id", "Nombres", horario.IdPersonal);
            return View(horario);
        }

        // POST: Horarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPersonal,Lunes,Martes,Miercoles,Jueves,Viernes,Sabado,Mes,Permiso,UsuarioRegistro,FechaRegistro,Estado")] Horario horario)
        {
            if (id != horario.Id)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(horario.Lunes))
            {
                try
                {
                    horario.UsuarioRegistro = User.Identity?.Name;
                    horario.FechaRegistro = DateTime.Now;
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HorarioExists(horario.Id))
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
            ViewData["IdPersonal"] = new SelectList(_context.Personals, "Id", "Nombres", horario.IdPersonal);
            return View(horario);
        }

        // GET: Horarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios
                .Include(h => h.IdPersonalNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }

        // POST: Horarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Horarios == null)
            {
                return Problem("Entity set 'LabConsultorioOdontologicoContext.Horarios'  is null.");
            }
            var horario = await _context.Horarios.FindAsync(id);
            if (horario != null)
            {
                horario.Estado = -1;
                horario.UsuarioRegistro = User.Identity?.Name;
                //_context.Horarios.Remove(horario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HorarioExists(int id)
        {
          return (_context.Horarios?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
