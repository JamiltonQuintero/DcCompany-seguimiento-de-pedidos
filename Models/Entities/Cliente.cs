using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.Entities
{
    public class Cliente
    {
        [DisplayName("Numero de casillero")]
        public int ClienteId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]

        [DisplayName("Correo electronico")]
        public string Correo { get; set; }
        [Required]
        public string Direccion { get; set; }
        public virtual Paquete Paquete { get; set; }
    }
}
