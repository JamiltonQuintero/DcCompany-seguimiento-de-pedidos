﻿using Microsoft.AspNetCore.Mvc.Rendering;
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



    public class PaqueteBusiness : IPaqueteBusiness
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
            return await _context.Paquetes.
                Include("Cliente").
                Include(tm => tm.TipoMercancia).
                Include(t => t.Transportadora).ToListAsync();
        }

        public async Task<Paquete> ObtenerPaquetePorId(int id)
        {
            return await _context.Paquetes
                .Include(p => p.Cliente).Include(tm => tm.TipoMercancia).Include(t => t.Transportadora)
                .FirstOrDefaultAsync(m => m.PaqueteId == id);
        }


        public async Task GuardarPaquete(Paquete paquete)
        {
            paquete.CodigoMIA = ("MIA-" + ObtenerUltimoId());

            if (paquete.ValorAPAgar == 0)
            {
                paquete.ValorAPAgar = ((float)(paquete.Peso * 100));
            }

            try
            {

                _context.Add(paquete);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
            }


        }

        public async Task EditarPaquete(Paquete paquete)
        {

            if (paquete.ValorAPAgar == 0)
            {
                paquete.ValorAPAgar = ((float)(paquete.Peso * 100));
            }

            try
            {
                _context.Update(paquete);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }
        public async Task EliminarPaquete(Paquete paquete)
        {

            try
            {
                _context.Paquetes.Remove(paquete);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

            }
        }



        private int ObtenerUltimoId()
        {

            var ultmoId = _context.Paquetes.Count();

            return ultmoId;
        }

        public async Task<IEnumerable<Paquete>> ObtenerListaPaquetesPorClienteId(int id)
        {
            return await _context.Paquetes.Include(t => t.Transportadora).Include(tm => tm.TipoMercancia).Where(paquete => paquete.ClienteId == id).ToListAsync();
        }
    }

}