using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.ViewModels
{
    public class PaqueteViewModel
    {

        public string CodigoMIA { get; set; }
        public double Peso { get; set; }       
        public string NombreImagen { get; set; }
        public IFormFile Imagen { get; set; }
        public String Estado { get; set; }
        public int GuiaColombia { get; set; }
        public float ValorAPAgar { get; set; }
        public int ClienteId { get; set; }
        public int TransportadoraId { get; set; }
        public int TipoMercanciaId{ get; set; }

    }


}
