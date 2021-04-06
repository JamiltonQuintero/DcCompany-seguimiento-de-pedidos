using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Models.Abstract
{
    public interface IPaqueteBusiness
    {


        Task<IEnumerable<Cliente>> ObtenerListaClientes();

        Task<IEnumerable<Transportadora>> ObtenerListaTransportadora();

        Task<IEnumerable<TipoMercancia>> ObtenerListaTipoMercancia();

        Task<IEnumerable<Paquete>> ObtenerListaPaquetes();

        Task<Paquete> ObtenerPaquetePorId(int id);

        Task GuardarPaquete(Paquete paquete);

    }
}
