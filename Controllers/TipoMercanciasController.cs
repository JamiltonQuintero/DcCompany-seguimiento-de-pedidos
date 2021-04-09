using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerCuatro.Models.DAL;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Controllers
{
    
    public class TipoMercanciasController : Controller
    {
        private readonly DbContextTaller _context;

        public TipoMercanciasController(DbContextTaller context)
        {
            _context = context;
        }

        // GET: TipoMercancias
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposMercancias.ToListAsync());
        }

        // GET: TipoMercancias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercancia = await _context.TiposMercancias
                .FirstOrDefaultAsync(m => m.TipoMercanciaId == id);
            if (tipoMercancia == null)
            {
                return NotFound();
            }

            return View(tipoMercancia);
        }

        // GET: TipoMercancias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoMercancias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoMercanciaId,Nombre")] TipoMercancia tipoMercancia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoMercancia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoMercancia);
        }

        // GET: TipoMercancias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercancia = await _context.TiposMercancias.FindAsync(id);
            if (tipoMercancia == null)
            {
                return NotFound();
            }
            return View(tipoMercancia);
        }

        // POST: TipoMercancias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoMercanciaId,Nombre")] TipoMercancia tipoMercancia)
        {
            if (id != tipoMercancia.TipoMercanciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoMercancia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoMercanciaExists(tipoMercancia.TipoMercanciaId))
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
            return View(tipoMercancia);
        }

        // GET: TipoMercancias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercancia = await _context.TiposMercancias
                .FirstOrDefaultAsync(m => m.TipoMercanciaId == id);
            if (tipoMercancia == null)
            {
                return NotFound();
            }

            return View(tipoMercancia);
        }

        // POST: TipoMercancias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoMercancia = await _context.TiposMercancias.FindAsync(id);
            _context.TiposMercancias.Remove(tipoMercancia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoMercanciaExists(int id)
        {
            return _context.TiposMercancias.Any(e => e.TipoMercanciaId == id);
        }
    }
}
