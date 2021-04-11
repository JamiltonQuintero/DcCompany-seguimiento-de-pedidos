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
    public class TransportadoraBusiness : ITransportadoraBusiness
    {
        private readonly DbContextTaller _context;
        public TransportadoraBusiness(DbContextTaller context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Transportadora>> ObtenerListaTransportadoras()
        {
            return await _context.Transportadoras.ToListAsync();
        }
        public async Task<Transportadora> ObtenerTransportadoraPorId(int id)
        {
            return await _context.Transportadoras.FirstOrDefaultAsync(t => t.TransportadoraId == id);

        }


        public async Task GuardarTransportadora(Transportadora transportadora)
        {
            try
            {
                _context.Add(transportadora);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task EditarTransportadora(Transportadora transportadora)
        {
            try
            {
                _context.Update(transportadora);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task EliminarTransportadora(Transportadora transportadora)
        {
            try
            {
                _context.Remove(transportadora);
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}
