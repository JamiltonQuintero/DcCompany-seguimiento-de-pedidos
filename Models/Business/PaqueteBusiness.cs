using Microsoft.AspNetCore.Mvc.Rendering;
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

    

    public class PaqueteBusiness :IPaqueteBusiness
    {

        private readonly DbContextTaller _context;

        public PaqueteBusiness(DbContextTaller context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Cliente>> ObtenerListaClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<IEnumerable<Transportadora>> ObtenerListaTransportadora()
        {
            return await _context.Transportadoras.ToListAsync();
        }

        public async Task<IEnumerable<TipoMercancia>> ObtenerListaTipoMercancia()
        {
            return await _context.TiposMercancias.ToListAsync();
        }

        public async Task<IEnumerable<Paquete>> ObtenerListaPaquetes()
        {
            return await _context.Paquetes.Include("Cliente").ToListAsync();
        }

        public async Task<Paquete> ObtenerPaquetePorId(int id)
        {
            return await _context.Paquetes
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.PaqueteId == id);
        }


        public async Task GuardarPaquete(Paquete paquete)
        {
            _context.Add(paquete);
            await ActulizarBD();
        }


        private async Task ActulizarBD()
        {

            await _context.SaveChangesAsync();

        }

    }

}
