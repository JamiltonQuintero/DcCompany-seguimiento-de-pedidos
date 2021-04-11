using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerCuatro.Models.Abstract;
using TallerCuatro.Models.DAL;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Models.Business
{
    public class ClienteBusiness :IClienteBusiness
    {


        private readonly DbContextTaller _context;
        public ClienteBusiness(DbContextTaller context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cliente>> ObtenerListaClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            return await _context.Clientes.FirstOrDefaultAsync(m => m.ClienteId == id);

        }
        public async Task GuardarCliente(Cliente cliente)
        {
            try
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task EditarCliente(Cliente cliente)
        {
            try
            {
                _context.Update(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task EliminarCliente(Cliente cliente)
        {
            try
            {
                _context.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        }/*
        public async Task<IEnumerable<ClienteDetalle>> ObtenerClienteDetalleporId(int id)
        {
            return await _context.ClienteDetalle.Include(x => x.Paquete).Where(y => y.EmpleadoId == id).ToListAsync();
        }*/







    }
}
