using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerCuatro.Models.Abstract;
using TallerCuatro.Models.DAL;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly IPaqueteBusiness _paqueteBusiness;

        public PaquetesController(IPaqueteBusiness paqueteBusiness)
        {
            _paqueteBusiness = paqueteBusiness;
        }

        // GET: Paquetes
        public async Task<IActionResult> Index()
        {

            var paquetes = _paqueteBusiness.ObtenerListaPaquetes();

            return View(await paquetes);
        }

        // GET: Paquetes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _paqueteBusiness.ObtenerPaquetePorId(id.Value);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        // GET: Paquetes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ClienteId"] = new SelectList(await _paqueteBusiness.ObtenerListaClientes(), "ClienteId", "Nombre") ;
            ViewData["TransportadoraId"] = new SelectList(await _paqueteBusiness.ObtenerListaTransportadora(), "TransportadoraId", "Nombre");
            ViewData["TipoMercanciaId"] = new SelectList(await _paqueteBusiness.ObtenerListaTipoMercancia(), "TipoMercanciaId", "Nombre");
            return View();
        }

        // POST: Paquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaqueteId,CodigoMIA,Peso,ClienteId, Estado,NombreImagen,TransportadoraId,TipoMercanciaId, GuiaColombia, ValorAPAgar")] Paquete paquete)
        {
            if (ModelState.IsValid)
            {
 

                await _paqueteBusiness.GuardarPaquete(paquete);

                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(await _paqueteBusiness.ObtenerListaClientes(), "ClienteId", "Nombre");
            ViewData["TransportadoraId"] = new SelectList(await _paqueteBusiness.ObtenerListaTransportadora(), "TransportadoraId", "Nombre");
            ViewData["TipoMercanciaId"] = new SelectList(await _paqueteBusiness.ObtenerListaTipoMercancia(), "TipoMercanciaId", "Nombre");
            return View(paquete);
        }

        /*
        // GET: Paquetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", paquete.ClienteId);
            return View(paquete);
        }

        // POST: Paquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaqueteId,Nombre,ClienteId")] Paquete paquete)
        {
            if (id != paquete.PaqueteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paquete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaqueteExists(paquete.PaqueteId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "ClienteId", paquete.ClienteId);
            return View(paquete);
        }

        // GET: Paquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquete = await _context.Paquetes
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PaqueteId == id);
            if (paquete == null)
            {
                return NotFound();
            }

            return View(paquete);
        }

        // POST: Paquetes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paquete = await _context.Paquetes.FindAsync(id);
            _context.Paquetes.Remove(paquete);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaqueteExists(int id)
        {
            return _context.Paquetes.Any(e => e.PaqueteId == id);
        }*/
    }
}
