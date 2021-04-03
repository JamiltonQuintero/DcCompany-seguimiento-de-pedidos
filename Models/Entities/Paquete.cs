using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerCuatro.Models.Entities
{
    public class Paquete
    {

        public int PaqueteId { get; set; }
        public string Nombre { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

    }
}
