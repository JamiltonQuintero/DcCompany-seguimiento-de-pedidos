using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Models.Abstract
{
    public interface ITransportadoraBusiness
    {

        Task<IEnumerable<Transportadora>> ObtenerListaTransportadoras();
        Task<Transportadora> ObtenerTransportadoraPorId (int id);
        Task GuardarTransportadora(Transportadora transportadora);
        Task EditarTransportadora(Transportadora transportadora);
        Task EliminarTransportadora(Transportadora transportadora);
    }
}
