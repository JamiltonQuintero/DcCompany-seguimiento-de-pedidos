using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TallerCuatro.Models.Entities;

namespace TallerCuatro.Models.DAL
{
    public class DbContextTaller : DbContext
    {
        public DbContextTaller(DbContextOptions<DbContextTaller> options): base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Paquete> Paquetes { get; set; }

    }
}
