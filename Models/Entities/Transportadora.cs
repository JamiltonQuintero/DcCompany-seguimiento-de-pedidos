using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.Entities
{
    public class Transportadora
    {
        [Key]

        public int TransportadoraId { get; set; }
        [Required]
        public int Rut { get; set; }
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Ciudad de sede principal")]
        public string CiudadSede { get; set; }

        public string Direccion { get; set; }
        [Required]
        public int Telefono { get; set; }
        

    }
}
