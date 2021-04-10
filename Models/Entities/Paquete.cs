using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.Entities
{
    public class Paquete
    {
        [Key]
        public int PaqueteId { get; set; }
        public string CodigoMIA { get; set; }
        public double Peso { get; set; }
        public String NombreImagen { get; set; }

        public String Estado { get; set; }

        public int GuiaColombia { get; set; }

        public float ValorAPAgar { get; set; }

        [ForeignKey("TransportadoraId")]
        public int TransportadoraId { get; set; }
        public virtual Transportadora Transportadora { get; set; }

        [ForeignKey("TipoMercanciaId")]
        public int TipoMercanciaId{ get; set; }
        public virtual TipoMercancia TipoMercancia { get; set; }

        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
