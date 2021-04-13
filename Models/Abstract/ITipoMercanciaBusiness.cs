using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Models.Abstract
{
    public interface ITipoMercanciaBusiness
    {
        Task<IEnumerable<TipoMercancia>> ObtenerListaTipoMercancia();
        Task<TipoMercancia> ObtenerTipoMercanciaPorId(int id);
        Task GuardarTipoMercancia(TipoMercancia tipoMercancia);
        Task EditarTipoMercancia(TipoMercancia tipoMercancia);
        Task EliminarTipoMercancia(TipoMercancia tipoMercancia);
    }
}
