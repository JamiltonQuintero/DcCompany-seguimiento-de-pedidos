using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerCuatro.Models.Abstract;
using TallerCuatro.Models.DAL;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Controllers
{
    public class TransportadorasController : Controller
    {
        private readonly ITransportadoraBusiness _transportadoraBusiness;

        public TransportadorasController(ITransportadoraBusiness transportadoraBusiness)
        {
            _transportadoraBusiness = transportadoraBusiness;
        }

        // GET: Transportadoras
        public async Task<IActionResult> Index()
        {
            return View(await _transportadoraBusiness.ObtenerListaTransportadoras());
        }

        // GET: Transportadoras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportadora = await _transportadoraBusiness.ObtenerTransportadoraPorId(id.Value);            
           
            if (transportadora == null)
            {
                return NotFound();
            }

            return View(transportadora);
        }

        // GET: Transportadoras/Create
        public async Task<IActionResult> Create()
        {
            ViewData["listaTransportadoras"] = new SelectList(await _transportadoraBusiness.ObtenerListaTransportadoras(),"Rut", "Nombre", "Telefono", "Ciudad de sede principal");
            return View();
        }

        // POST: Transportadoras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("TransportadoraId,Rut,Nombre,CiudadSede,Direccion,Telefono")] Transportadora transportadora)
        {
            if (ModelState.IsValid)
            {
                var verificarExistenciaTransportadoraId = await _transportadoraBusiness.ObtenerTransportadoraPorId(transportadora.TransportadoraId);
                if (verificarExistenciaTransportadoraId == null)
                {
                    await _transportadoraBusiness.GuardarTransportadora(transportadora);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(transportadora);
        }

        // GET: Transportadoras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportadora = await _transportadoraBusiness.ObtenerTransportadoraPorId(id.Value);
            if (transportadora == null)
            {
                return NotFound();
            }
            return View(transportadora);
        }

        // POST: Transportadoras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("TransportadoraId,Nombre")] Transportadora transportadora)
        {
            if (id != transportadora.TransportadoraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _transportadoraBusiness.EditarTransportadora(transportadora);
                return RedirectToAction(nameof(Index));
            }
            ViewData["listaTransportadoras"] = _transportadoraBusiness.ObtenerListaTransportadoras();
            return View(transportadora);
        }

        // GET: Transportadoras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transportadora = await _transportadoraBusiness.ObtenerTransportadoraPorId(id.Value);
            if (transportadora == null)
            {
                return NotFound();
            }

            await _transportadoraBusiness.EliminarTransportadora(transportadora);
            return View(transportadora);
        }

        /*// POST: Transportadoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transportadora = await _context.Transportadoras.FindAsync(id);
            _context.Transportadoras.Remove(transportadora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportadoraExists(int id)
        {
            return _context.Transportadoras.Any(e => e.TransportadoraId == id);
        }*/
    }
}