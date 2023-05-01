using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practico_2.Data;

namespace Practico_2.Controllers
{
    public class EstatusController : Controller
    {
        private readonly DataContext _context;

        public EstatusController(DataContext context)
        {
            _context = context;
        }

        // GET: Estatus
        public async Task<IActionResult> Index()
        {
              return _context.Estatus != null ? 
                          View(await _context.Estatus.ToListAsync()) :
                          Problem("Entity set 'DataContext.Estatus'  is null.");
        }

        // GET: Estatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Estatus == null)
            {
                return NotFound();
            }

            var estatus = await _context.Estatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estatus == null)
            {
                return NotFound();
            }

            return View(estatus);
        }

        // GET: Estatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Estatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,FechaDeAlta")] Estatus estatus)
        {
            ModelState.Remove("Profesores");
            ModelState.Remove("Cursos");
            ModelState.Remove("Estudiantes");
            if (ModelState.IsValid)
            {
                _context.Add(estatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estatus);
        }

        // GET: Estatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Estatus == null)
            {
                return NotFound();
            }

            var estatus = await _context.Estatus.FindAsync(id);
            if (estatus == null)
            {
                return NotFound();
            }
            return View(estatus);
        }

        // POST: Estatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,FechaDeAlta")] Estatus estatus)
        {
            if (id != estatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstatusExists(estatus.Id))
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
            return View(estatus);
        }

        // GET: Estatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Estatus == null)
            {
                return NotFound();
            }

            var estatus = await _context.Estatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estatus == null)
            {
                return NotFound();
            }

            return View(estatus);
        }

        // POST: Estatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Estatus == null)
            {
                return Problem("Entity set 'DataContext.Estatus'  is null.");
            }
            var estatus = await _context.Estatus.FindAsync(id);
            if (estatus != null)
            {
                _context.Estatus.Remove(estatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstatusExists(int id)
        {
          return (_context.Estatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
