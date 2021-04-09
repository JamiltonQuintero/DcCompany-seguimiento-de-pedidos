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

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<TipoMercancia> TiposMercancias { get; set; }
        public DbSet<UsuarioIdentity> UsuariosIdentity { get; set; }

    }
}
