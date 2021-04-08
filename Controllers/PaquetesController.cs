using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TallerCuatro.Models.Abstract;
using TallerCuatro.Models.DAL;
using TallerCuatro.Models.Entities;
using TallerCuatro.Models.ViewModels;

namespace TallerCuatro.Controllers
{
    public class PaquetesController : Controller
    {
        private readonly IPaqueteBusiness _paqueteBusiness;
        private readonly IClienteBusiness _clienteBusiness;
        private readonly IWebHostEnvironment _hostEnvironment;

        public PaquetesController(IPaqueteBusiness paqueteBusiness, IClienteBusiness clienteBusiness, IWebHostEnvironment hostEnvironment)
        {
            _paqueteBusiness = paqueteBusiness;
            _clienteBusiness = clienteBusiness;
            _hostEnvironment = hostEnvironment;
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

            
            ViewData["listaClientes"] = new SelectList(await _paqueteBusiness.ObtenerListaClientes(), "ClienteId", "Nombre") ;
            ViewData["listaTransportadoras"] = new SelectList(await _paqueteBusiness.ObtenerListaTransportadora(), "TransportadoraId", "Nombre");
            ViewData["listaTipomercancias"] = new SelectList(await _paqueteBusiness.ObtenerListaTipoMercancia(), "TipoMercanciaId", "Nombre");
            return View();
        }

        // POST: Paquetes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaqueteViewModel paqueteViewModel)
        {
          

                if (paqueteViewModel.ClienteId != 0 && paqueteViewModel.Peso != 0 && paqueteViewModel.Imagen != null)
                {

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string nombreImagen = Path.GetFileNameWithoutExtension(paqueteViewModel.Imagen.FileName);
                    string extension = Path.GetExtension(paqueteViewModel.Imagen.FileName);
                    nombreImagen = nombreImagen + DateTime.Now.ToString("yymmssfff") + extension;

                Paquete paquete = new Paquete
                {
                        CodigoMIA = "",
                        Peso = paqueteViewModel.Peso,
                        NombreImagen = nombreImagen,
                        Estado = paqueteViewModel.Estado,
                        GuiaColombia = paqueteViewModel.GuiaColombia,
                        ValorAPAgar = paqueteViewModel.ValorAPAgar,
                        ClienteId = paqueteViewModel.ClienteId,
                        TransportadoraId = paqueteViewModel.TransportadoraId,
                        TipoMercanciaId = paqueteViewModel.TipoMercanciaId
                    };

                    string path = Path.Combine(wwwRootPath + "/image/" + nombreImagen);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await paqueteViewModel.Imagen.CopyToAsync(fileStream);
                    }
                    try
                    {
                        await _paqueteBusiness.GuardarPaquete(paquete);
                        return Json(new { data = "ok" });
                    }
                    catch (Exception)
                    {
                        return Json(new { data = "error" });
                    }
                        
                }
                return Json(new { data = "error" });
       

            /*
            ViewData["ClienteId"] = new SelectList(await _paqueteBusiness.ObtenerListaClientes(), "ClienteId", "Nombre");
            ViewData["TransportadoraId"] = new SelectList(await _paqueteBusiness.ObtenerListaTransportadora(), "TransportadoraId", "Nombre");
            ViewData["TipoMercanciaId"] = new SelectList(await _paqueteBusiness.ObtenerListaTipoMercancia(), "TipoMercanciaId", "Nombre");
            return View(paquete);*/
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
