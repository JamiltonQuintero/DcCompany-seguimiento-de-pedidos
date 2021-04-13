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
    public class TipoMercanciaBusiness : ITipoMercanciaBusiness
    {
        private readonly DbContextTaller _context;
        public TipoMercanciaBusiness(DbContextTaller context)
        {
            _context = context;
        }
        public async Task<TipoMercancia> ObtenerTipoMercanciaPorId(int id)
        {
         return await _context.TiposMercancias.FirstOrDefaultAsync(tm => tm.TipoMercanciaId== id);;

        }
        public async Task<IEnumerable<TipoMercancia>> ObtenerListaTipoMercancia()
        {
            return await _context.TiposMercancias.ToListAsync();
        }
        public async Task GuardarTipoMercancia(TipoMercancia tipoMercancia)
        {
            try
            {
                _context.Add(tipoMercancia);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task EditarTipoMercancia(TipoMercancia tipoMercancia)
        {
            try
            {
                _context.Update(tipoMercancia);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task EliminarTipoMercancia(TipoMercancia tipoMercancia)
        {
            try
            {
                _context.Remove(tipoMercancia);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
