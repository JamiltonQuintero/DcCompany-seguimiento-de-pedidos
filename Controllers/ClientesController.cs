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
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly IClienteBusiness _clienteBusiness;

        public ClientesController(IClienteBusiness clienteBusiness)
        {
            _clienteBusiness = clienteBusiness;
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
                
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public async Task<IActionResult> Create()
        {
            ViewData["listaClientes"] = new SelectList(await _clienteBusiness.ObtenerListaClientes(), "Numero de casillero", "Nombre", "Correo", "Direcion");
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
                var clienteTemp = await _clienteBusiness.ObtenerClientePorId(cliente.ClienteId);

                if (clienteTemp == null)
                {
                    await _clienteBusiness.GuardarCliente(cliente);
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(cliente);
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
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _clienteBusiness.EditarCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            ViewData["listaClientes"] = _clienteBusiness.ObtenerListaClientes();
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleado = await _clienteBusiness.ObtenerClientePorId(id.Value);
            if (empleado == null)
            {
                return NotFound();
            }

            await _clienteBusiness.EliminarCliente(empleado);

            return RedirectToAction(nameof(Index));
        }
       

        
    }
}
