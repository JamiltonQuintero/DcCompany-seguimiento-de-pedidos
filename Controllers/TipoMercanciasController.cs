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

    public class TipoMercanciasController : Controller
    {
        private readonly ITipoMercanciaBusiness _tipoMercanciasBusiness;

        public TipoMercanciasController (ITipoMercanciaBusiness tipoMercanciasBusiness)
        {
            _tipoMercanciasBusiness = tipoMercanciasBusiness;
        }


        // GET: TipoMercancias
        public async Task<IActionResult> Index()
        {
            return View(await _tipoMercanciasBusiness.ObtenerListaTipoMercancia());

        }

        // GET: TipoMercancias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercancia = await _tipoMercanciasBusiness.ObtenerTipoMercanciaPorId(id.Value);

            if (tipoMercancia == null)
            {
                return NotFound();
            }

            return View(tipoMercancia);
        }

        // GET: TipoMercancias/Create
        public async Task<IActionResult> Create()
        {
            ViewData["listaTipoMercancias"] = new SelectList(await _tipoMercanciasBusiness.ObtenerListaTipoMercancia(), "TipoMercanciaId","Nombre", "Transportadora Encargada");

            return View();
        }

        // POST: TipoMercancias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("TipoMercanciaId", "Nombre")] TipoMercancia tipoMercancia)
        {
            if (ModelState.IsValid)
            {
                var verificarExistenciaTipoMercanciaId = await _tipoMercanciasBusiness.ObtenerTipoMercanciaPorId(tipoMercancia.TipoMercanciaId);
                
                if (verificarExistenciaTipoMercanciaId == null)
                {
                    await _tipoMercanciasBusiness.GuardarTipoMercancia(tipoMercancia);
                    return RedirectToAction(nameof(Index));
                }
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

            var tipoMercancia = await _tipoMercanciasBusiness.ObtenerTipoMercanciaPorId(id.Value);
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
        public async Task<IActionResult> Edit(int id, [Bind("TipoMercanciaId,Nombre")] TipoMercancia tipoMercancia)
        {
            if (id != tipoMercancia.TipoMercanciaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _tipoMercanciasBusiness.EditarTipoMercancia(tipoMercancia);
                return RedirectToAction(nameof(Index));
            }
            ViewData["listaTiposMercancias"] = _tipoMercanciasBusiness.ObtenerListaTipoMercancia();

            return View(tipoMercancia);
        }

        // GET: TipoMercancias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoMercancia = await _tipoMercanciasBusiness.ObtenerTipoMercanciaPorId(id.Value);
            if (tipoMercancia == null)
            {   
                return NotFound();
            }

            await _tipoMercanciasBusiness.EliminarTipoMercancia(tipoMercancia);
            return View(tipoMercancia);
        }

    }
}