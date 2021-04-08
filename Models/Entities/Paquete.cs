using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.Entities
{
    public class Paquete
    {

        public int PaqueteId { get; set; }
        public string CodigoMIA { get; set; }
        public double Peso { get; set; }
        public String NombreImagen { get; set; }

        public String Estado { get; set; }

        public int GuiaColombia { get; set; }

        public float ValorAPAgar { get; set; }

        public int TransportadoraId { get; set; }
        public virtual Transportadora Transportadora { get; set; }

        public int TipoMercanciaId { get; set; }
        public virtual TipoMercancia TipoMercancia { get; set; }
       

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
