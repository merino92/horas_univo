using System;
using Microsoft.EntityFrameworkCore;
using univo.Models;

namespace univo.data
{
    public class univoContext:DbContext
    {
     public univoContext(DbContextOptions<univoContext> opciones):base(opciones) { }

        public DbSet<Modulos> modulos { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<RolesPermisos> roles_permisos { get; set; }
        public DbSet<Usuarios> usuarios { get; set; }

        
    }
}
