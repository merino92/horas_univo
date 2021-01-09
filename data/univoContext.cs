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
        public DbSet<Facultades> facultades{get;set;}
        public DbSet<Carreras> carreras{get;set;}
        public DbSet<Productos> productos{get;set;}
        public DbSet<Movimientos> movimientos{get;set;}
        public DbSet<Boletas> boletas{get;set;}
        public DbSet<BoletasDetalles> boletasdetalles{get;set;}
        public DbSet<Requisiciones> requisiciones{get;set;}
        public DbSet<RequisicionDetalles> requisiciondetalles{get;set;}
        public DbSet<Boletacarreras> boletacarreras{get;set;}
        public DbSet<Materias> materias{get;set;}
        public DbSet<Boletamaterias> boletamaterias{get;set;}
        

    }
}
