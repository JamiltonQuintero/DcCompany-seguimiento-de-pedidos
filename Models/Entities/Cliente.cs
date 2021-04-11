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
        [DisplayName("Número de casillero")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        

        [DisplayName("Correo electrónico")]
        [Required(ErrorMessage = "El correo electrónico  es requerido")]
        [EmailAddress(ErrorMessage = "Correo electrónico inválido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La dirección es requerida")]
        public string Direccion { get; set; }
        public virtual Paquete Paquete { get; set; }
    }
}
