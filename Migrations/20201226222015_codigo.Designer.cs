﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using univo.data;

namespace univo.Migrations
{
    [DbContext(typeof(univoContext))]
    [Migration("20201226222015_codigo")]
    partial class codigo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("univo.Models.Boletacarreras", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<int>("idboleta")
                        .HasColumnType("int");

                    b.Property<int>("idcarrera")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idboleta");

                    b.HasIndex("idcarrera");

                    b.ToTable("boletacarreras");
                });

            modelBuilder.Entity("univo.Models.Boletamaterias", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<int>("idboleta")
                        .HasColumnType("int");

                    b.Property<int>("idmateria")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idboleta");

                    b.HasIndex("idmateria");

                    b.ToTable("boletamaterias");
                });

            modelBuilder.Entity("univo.Models.Boletas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<int?>("carrerasid")
                        .HasColumnType("int");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("devuelto")
                        .HasColumnType("bit");

                    b.Property<string>("encargado")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<int?>("facultadesid")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idusuario")
                        .HasColumnType("int");

                    b.Property<bool>("parcial")
                        .HasColumnType("bit");

                    b.Property<int?>("usuariosid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("carrerasid");

                    b.HasIndex("facultadesid");

                    b.HasIndex("usuariosid");

                    b.ToTable("boletas");
                });

            modelBuilder.Entity("univo.Models.BoletasDetalles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("iddetalle")
                        .HasColumnType("int");

                    b.Property<int>("idproducto")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("iddetalle");

                    b.HasIndex("idproducto");

                    b.ToTable("boletasdetalles");
                });

            modelBuilder.Entity("univo.Models.Carreras", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<string>("carrerra")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("idfacultad")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idfacultad");

                    b.ToTable("carreras");
                });

            modelBuilder.Entity("univo.Models.Facultades", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("facultades");
                });

            modelBuilder.Entity("univo.Models.Materias", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<string>("materia")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("id");

                    b.ToTable("materias");
                });

            modelBuilder.Entity("univo.Models.Modulos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<string>("modulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("modulos");
                });

            modelBuilder.Entity("univo.Models.Movimientos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<string>("concepto")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("entrada")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idproducto")
                        .HasColumnType("int");

                    b.Property<int>("idusuario")
                        .HasColumnType("int");

                    b.Property<int>("saldo")
                        .HasColumnType("int");

                    b.Property<int>("salida")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idproducto");

                    b.HasIndex("idusuario");

                    b.ToTable("movimientos");
                });

            modelBuilder.Entity("univo.Models.Productos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<string>("codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("detalle")
                        .HasColumnType("text");

                    b.Property<int>("existencia")
                        .HasColumnType("int");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("imagen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marca")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("modelo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.HasKey("Id");

                    b.ToTable("productos");
                });

            modelBuilder.Entity("univo.Models.RequisicionDetalles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Movimientosid")
                        .HasColumnType("int");

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<int>("idproducto")
                        .HasColumnType("int");

                    b.Property<int>("idrequisicion")
                        .HasColumnType("int");

                    b.Property<int?>("idrequsicion")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Movimientosid");

                    b.HasIndex("idproducto");

                    b.HasIndex("idrequsicion");

                    b.ToTable("requisiciondetalles");
                });

            modelBuilder.Entity("univo.Models.Requisiciones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<string>("detalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<bool>("entrada")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("idusuario")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("idusuario");

                    b.ToTable("requisiciones");
                });

            modelBuilder.Entity("univo.Models.Roles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<string>("rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("univo.Models.RolesPermisos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("borrar")
                        .HasColumnType("bit");

                    b.Property<bool>("crear")
                        .HasColumnType("bit");

                    b.Property<bool>("editar")
                        .HasColumnType("bit");

                    b.Property<int?>("idmodulo")
                        .HasColumnType("int");

                    b.Property<bool>("imprimir")
                        .HasColumnType("bit");

                    b.Property<int>("moduloid")
                        .HasColumnType("int");

                    b.Property<int>("rolid")
                        .HasColumnType("int");

                    b.Property<bool>("visualizar")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("idmodulo");

                    b.HasIndex("rolid");

                    b.ToTable("roles_permisos");
                });

            modelBuilder.Entity("univo.Models.Usuarios", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellidos")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("borrado")
                        .HasColumnType("bit");

                    b.Property<string>("clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombres")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("rolid")
                        .HasColumnType("int");

                    b.Property<string>("usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.HasIndex("rolid");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("univo.Models.Boletacarreras", b =>
                {
                    b.HasOne("univo.Models.Boletas", "boletas")
                        .WithMany("boletacarreras")
                        .HasForeignKey("idboleta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("univo.Models.Carreras", "carreras")
                        .WithMany("boletacarreras")
                        .HasForeignKey("idcarrera")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("univo.Models.Boletamaterias", b =>
                {
                    b.HasOne("univo.Models.Boletas", "boletas")
                        .WithMany("boletamaterias")
                        .HasForeignKey("idboleta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("univo.Models.Materias", "materias")
                        .WithMany("boletamaterias")
                        .HasForeignKey("idmateria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("univo.Models.Boletas", b =>
                {
                    b.HasOne("univo.Models.Carreras", "carreras")
                        .WithMany()
                        .HasForeignKey("carrerasid");

                    b.HasOne("univo.Models.Facultades", "facultades")
                        .WithMany("boletas")
                        .HasForeignKey("facultadesid");

                    b.HasOne("univo.Models.Usuarios", "usuarios")
                        .WithMany("boletas")
                        .HasForeignKey("usuariosid");
                });

            modelBuilder.Entity("univo.Models.BoletasDetalles", b =>
                {
                    b.HasOne("univo.Models.Boletas", "boletas")
                        .WithMany("boletadetalles")
                        .HasForeignKey("iddetalle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("univo.Models.Productos", "Productos")
                        .WithMany("boletasdetalles")
                        .HasForeignKey("idproducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("univo.Models.Carreras", b =>
                {
                    b.HasOne("univo.Models.Facultades", "facultades")
                        .WithMany("carreras")
                        .HasForeignKey("idfacultad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("univo.Models.Movimientos", b =>
                {
                    b.HasOne("univo.Models.Productos", "productos")
                        .WithMany("movimientos")
                        .HasForeignKey("idproducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("univo.Models.Usuarios", "usuarios")
                        .WithMany("movimientos")
                        .HasForeignKey("idusuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("univo.Models.RequisicionDetalles", b =>
                {
                    b.HasOne("univo.Models.Movimientos", null)
                        .WithMany("RequisicionDetalles")
                        .HasForeignKey("Movimientosid");

                    b.HasOne("univo.Models.Productos", "producto")
                        .WithMany()
                        .HasForeignKey("idproducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("univo.Models.Requisiciones", "requisicion")
                        .WithMany()
                        .HasForeignKey("idrequsicion");
                });

            modelBuilder.Entity("univo.Models.Requisiciones", b =>
                {
                    b.HasOne("univo.Models.Usuarios", "usuarios")
                        .WithMany()
                        .HasForeignKey("idusuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("univo.Models.RolesPermisos", b =>
                {
                    b.HasOne("univo.Models.Modulos", "modulo")
                        .WithMany("rolespermisos")
                        .HasForeignKey("idmodulo");

                    b.HasOne("univo.Models.Roles", "rol")
                        .WithMany("rolespermisos")
                        .HasForeignKey("rolid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("univo.Models.Usuarios", b =>
                {
                    b.HasOne("univo.Models.Roles", "rol")
                        .WithMany()
                        .HasForeignKey("rolid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
