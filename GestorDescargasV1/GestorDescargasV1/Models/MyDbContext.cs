using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDescargasV1.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Explorar> Programas { get; set; }
        public DbSet<Descarga> Descargas  { get; set; }
        public DbSet<Registro> Usuarios { get; set; }
        public DbSet<Admins> Admins { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Explorar>().HasKey(e => e.idPrograma);
            modelBuilder.Entity<Descarga>().HasKey(e => e.idDescargas);
            modelBuilder.Entity<Registro>().HasKey(e => e.nombreUsuario);
            modelBuilder.Entity<Admins>().HasKey(e => e.Nombre);
        }
    }
}
