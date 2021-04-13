using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.ViewModels
{
    public class PaqueteViewModel
    {
        [DisplayName("Codigo Mia")]
        public string CodigoMIA { get; set; }
        [Required(ErrorMessage = "El peso es requerido")]
        public double Peso { get; set; }       
        public string NombreImagen { get; set; }

        [Required(ErrorMessage = "Imagen requerida")]
        public IFormFile Imagen { get; set; }
        public String Estado { get; set; }
        [Required(ErrorMessage = "La guia es requerida")]
        [DisplayName("Guia Colombiana")]
        public int GuiaColombia { get; set; }
        [DisplayName("Valor a Pagar")]
        public float ValorAPAgar { get; set; }
        [DisplayName("Cliente")]
        public int ClienteId { get; set; }
        [DisplayName("Transportadora")]
        public int TransportadoraId { get; set; }
        [DisplayName("Tipo de Mercancia")]
        public int TipoMercanciaId{ get; set; }

    }


}
