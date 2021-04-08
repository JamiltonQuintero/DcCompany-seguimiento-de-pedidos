using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Models.Abstract
{
    public interface IClienteBusiness
    {
        Task<IEnumerable<Cliente>> ObtenerListaClientes();

        Task<Cliente> ObtenerClientePorId(int id);
        Task GuardarCliente(Cliente cliente);
        Task EditarCliente(Cliente cliente);
        Task EliminarCliente(Cliente cliente);

    }
}
