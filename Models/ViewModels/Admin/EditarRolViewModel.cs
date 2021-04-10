using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.ViewModels.Admin
{
    public class EditarRolViewModel
    {

        public string Id { get; set; }
        [Required(ErrorMessage = "El nombre del rol es requerido")]
        public string NombreRol { get; set; }
        public List<string> Usuarios { get; set; }

    }
}
