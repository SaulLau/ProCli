#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProCli.Models;

namespace ProCli.Data
{
    public class ProCliContext : DbContext
    {
        public ProCliContext (DbContextOptions<ProCliContext> options)
            : base(options)
        {
        }

        public DbSet<ProCli.Models.Cliente> Cliente { get; set; }

        public DbSet<ProCli.Models.ContactosCliente> ContactosCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactosCliente>().ToTable("ContactosCliente");
        }
    }
}
