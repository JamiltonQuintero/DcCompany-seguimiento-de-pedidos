using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.Entities
{
    public class TipoMercancia
    {
        [Key]
        public int TipoMercanciaId { get; set; }
        public string Nombre { get; set; }

    }
}