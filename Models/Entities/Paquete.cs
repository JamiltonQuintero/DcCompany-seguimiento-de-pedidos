using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.Entities
{
    public class Paquete
    {
        [DisplayName("Identificador Paquete")]
        [Key]
        public int PaqueteId { get; set; }
        [DisplayName("Codigo Mia")]
        public string CodigoMIA { get; set; }

        [Required(ErrorMessage = "El peso es requerido")]
        public double Peso { get; set; }
        [Required(ErrorMessage = "Imagen requerida")]
        [DisplayName("Imagnen")]
        public String NombreImagen { get; set; }

        public String Estado { get; set; }

        [Required(ErrorMessage = "La guia es requerida")]
        [DisplayName("Guia Colombiana")]
        public int GuiaColombia { get; set; }

        [DisplayName("Valor a Pagar")]
        public float ValorAPAgar { get; set; }

        [Required(ErrorMessage = "La transprotadora es requerida")]

        [DisplayName("Transportadora")]
        [ForeignKey("TransportadoraId")]
        public int TransportadoraId { get; set; }
       
        public virtual Transportadora Transportadora { get; set; }

        [Required(ErrorMessage = "El t. mercancia es requerido")]
        [DisplayName("Tipo de Mercancia")]
        [ForeignKey("TipoMercanciaId")]
        public int TipoMercanciaId{ get; set; }
        public virtual TipoMercancia TipoMercancia { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        [DisplayName("Cliente")]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
