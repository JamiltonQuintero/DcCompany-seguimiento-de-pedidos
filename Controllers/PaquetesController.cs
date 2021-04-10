using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
                    catch (Exception )

                    {
                    
                        return Json(new { data = "error" });
                    }
                        
                }
                return Json(new { data = "error" });
       

          /*
            return View(paquete);*/
        }

        
        // GET: Paquetes/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            PaqueteViewModel paqueteViewModel = new PaqueteViewModel
            {
                CodigoMIA = paquete.CodigoMIA,
                Peso = paquete.Peso,
                NombreImagen = paquete.NombreImagen,
                Estado = paquete.Estado,
                GuiaColombia = paquete.GuiaColombia,
                ValorAPAgar = paquete.ValorAPAgar,
                ClienteId = paquete.ClienteId,
                TransportadoraId = paquete.TransportadoraId,
                TipoMercanciaId = paquete.TipoMercanciaId
            };

            ViewData["listaClientes"] = new SelectList(await _paqueteBusiness.ObtenerListaClientes(), "ClienteId", "Nombre");
            ViewData["listaTransportadoras"] = new SelectList(await _paqueteBusiness.ObtenerListaTransportadora(), "TransportadoraId", "Nombre");
            ViewData["listaTipomercancias"] = new SelectList(await _paqueteBusiness.ObtenerListaTipoMercancia(), "TipoMercanciaId", "Nombre");


            return View(paqueteViewModel);
        }

        // POST: Paquetes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PaqueteViewModel paqueteViewModel)
        {
            if (paqueteViewModel.ClienteId != 0 && paqueteViewModel.Peso != 0 && paqueteViewModel.Imagen != null)
            {

                Paquete paquete = new Paquete();
                if (paqueteViewModel.Imagen != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    //borramos la foto anterior
                    string imagenAnterior = null;
                    if (paqueteViewModel.NombreImagen != null)
                        imagenAnterior = Path.Combine(wwwRootPath, "image", paqueteViewModel.NombreImagen);

                    if (System.IO.File.Exists(imagenAnterior))
                        System.IO.File.Delete(imagenAnterior);

                    
                    string nombreImagen = Path.GetFileNameWithoutExtension(paqueteViewModel.Imagen.FileName);
                    string extension = Path.GetExtension(paqueteViewModel.Imagen.FileName);
                    paqueteViewModel.NombreImagen = nombreImagen = nombreImagen + DateTime.Now.ToString("yymmssfff") + extension;

                    string path = Path.Combine(wwwRootPath + "/image/" + nombreImagen);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await paqueteViewModel.Imagen.CopyToAsync(fileStream);
                    }
                    paquete.NombreImagen = paqueteViewModel.NombreImagen;

                } else
                {
                    paquete.NombreImagen = paqueteViewModel.NombreImagen;
                }

                    paquete.CodigoMIA = paqueteViewModel.CodigoMIA;
                    paquete.Peso = paqueteViewModel.Peso;
                    paquete.Estado = paqueteViewModel.Estado;
                    paquete.GuiaColombia = paqueteViewModel.GuiaColombia;
                    paquete.ValorAPAgar = paqueteViewModel.ValorAPAgar;
                    paquete.ClienteId = paqueteViewModel.ClienteId;
                    paquete.TransportadoraId = paqueteViewModel.TransportadoraId;
                    paquete.TipoMercanciaId = paqueteViewModel.TipoMercanciaId;

                try
                {
                    await _paqueteBusiness.EditarPaquete(paquete);
                    return Json(new { data = "ok" });
                }catch (Exception)
                {
                    return Json(new { data = "error" });
                }

            }
            return Json(new { data = "ok" });
        }
        
        // GET: Paquetes/Delete/5
        public async Task<IActionResult> Delete(int? id)
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
            await _paqueteBusiness.EliminarPaquete(paquete);
            return RedirectToAction(nameof(Index));
        }
        /*
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
