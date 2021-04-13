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
   
    public class ClientesController : Controller
    {
        private readonly IClienteBusiness _clienteBusiness;
        private readonly IPaqueteBusiness _paqueteBusiness;

        public ClientesController(IClienteBusiness clienteBusiness, IPaqueteBusiness paqueteBusiness)
        {
            _clienteBusiness = clienteBusiness;
            _paqueteBusiness = paqueteBusiness;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _clienteBusiness.ObtenerListaClientes());
        }
        
        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteBusiness.ObtenerClientePorId(id.Value);
            ViewData["PaquetesCliente"] = await _paqueteBusiness.ObtenerListaPaquetesPorClienteId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }


            return View(cliente);
        }

        // GET: Clientes/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,Nombre,Correo,Direccion")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                
                    try
                    {
                        await _clienteBusiness.GuardarCliente(cliente);
                        return Json(new { data = "ok" });
                    } 
                    catch(Exception)
                    {
                        return Json(new { data = "error" });
                    }
                
            }
            return Json(new { data = "error" });
        }


        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _clienteBusiness.ObtenerClientePorId(id.Value);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }
        

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nombre,Correo,Direccion")] Cliente cliente)
        {

            if (id != cliente.ClienteId)
            {
                return Json(new { data = "error" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteBusiness.EditarCliente(cliente);
                    return Json(new { data = "ok" });

                }
                catch (Exception)
                {

                    return Json(new { data = "error" });
                }
            }
            return Json(new { data = "error" });
        }
        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return Json(new { data = "error", message = "Id no encontrado"});
            }
            try
            {
                var cliente = await _clienteBusiness.ObtenerClientePorId(id.Value);
                if (cliente == null)
                    //return RedirectToAction("Error", "Admin");
                    return Json(new { data = "error", message = "Cliente a eliminar no existe" });
                await _clienteBusiness.EliminarCliente(cliente);
                
                return Json(new { data = "ok", message = "Cliente "+cliente.Nombre+" fue eliminado correctamente" });
            }
            catch (Exception)
            {
                //return RedirectToAction("Error", "Admin");
                return Json(new { data = "error", message = "Ocurrió un error al eliminar el cliente" });
            }
        }
   
    }
}
