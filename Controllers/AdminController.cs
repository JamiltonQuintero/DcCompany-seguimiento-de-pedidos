using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerCuatro.Models.Abstract;
using TallerCuatro.Models.Entities;
using TallerCuatro.Models.ViewModels.Admin;

namespace TallerCuatro.Controllers
{
    
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly IPaqueteBusiness _paqueteBusiness;


        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<UsuarioIdentity> userManager, IPaqueteBusiness paqueteBusiness)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _paqueteBusiness = paqueteBusiness;
 
        }

        public IActionResult Dashboard()
        {
            var reporte = _paqueteBusiness.ReporteDashboar();
            return View(reporte);
        }

        public IActionResult CrearRol()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CrearRol(RolViewModel rolViewModel)
        {

            if (ModelState.IsValid)
            {

                IdentityRole rol = new IdentityRole
                {
                    Name = rolViewModel.NombreRol
                };

                var result = await _roleManager.CreateAsync(rol);

                if (result.Succeeded)
                {
                    TempData["Accion"] = "CrearRol";
                    TempData["Mensaje"] = "Rol " + rol.Name +" creado";
                    return RedirectToAction("ListarRoles", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                

            }

            return View(rolViewModel);
        }

        public IActionResult ListarRoles()
        {
            return View(_roleManager.Roles);
        }


        public async Task<IActionResult> EditarRol(string id)
        {
            var rol = await _roleManager.FindByIdAsync(id);
            if (rol == null)
            {
                ViewData["Error"] = $"El rol con id {id} no se encontró";
                return View("NotFound");
            }
            var editarRolViewModel = new EditarRolViewModel
            {
                Id = rol.Id,
                NombreRol = rol.Name
            };

            foreach (var usuario in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(usuario, rol.Name))
                {
                    editarRolViewModel.Usuarios.Add(usuario.UserName);
                }

            }
            return View(editarRolViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> EditarRol(EditarRolViewModel editarRolViewModel)
        {
            var rol = await _roleManager.FindByIdAsync(editarRolViewModel.Id);
            if (rol == null)
            {
                ViewData["Error"] = $"El rol con id {editarRolViewModel.Id} no se encontró";
                return View("NotFound");
            }
            else
            {
                rol.Name = editarRolViewModel.NombreRol;
                var result = await _roleManager.UpdateAsync(rol);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListarRoles");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);

                }
            }


            return View(editarRolViewModel);
        }


    }


}
