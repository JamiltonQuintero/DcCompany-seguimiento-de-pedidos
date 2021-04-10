using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Models.DAL
{
    public class DbContextTaller : IdentityDbContext
    {
        public DbContextTaller(DbContextOptions<DbContextTaller> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Paquete>().HasIndex(s => s.ClienteId).IsUnique(false);
            /*
            builder.Entity<TipoMercancia>().HasIndex(s => s.TipoMercanciaId).IsUnique(false);
            builder.Entity<Transportadora>().HasIndex(s => s.TransportadoraId).IsUnique(false);*/
            base.OnModelCreating(builder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<TipoMercancia> TiposMercancias { get; set; }
        public DbSet<UsuarioIdentity> UsuariosIdentity { get; set; }

    }
}
