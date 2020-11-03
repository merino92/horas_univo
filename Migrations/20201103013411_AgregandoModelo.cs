using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class AgregandoModelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "facultades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(maxLength: 50, nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facultades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "modulos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    modulo = table.Column<string>(maxLength: 50, nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<string>(maxLength: 25, nullable: false),
                    nombre = table.Column<string>(maxLength: 75, nullable: false),
                    marca = table.Column<string>(maxLength: 50, nullable: true),
                    existencia = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(type: "text", nullable: true),
                    imagen = table.Column<string>(nullable: true),
                    modelo = table.Column<string>(maxLength: 50, nullable: true),
                    fecha = table.Column<DateTime>(nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rol = table.Column<string>(maxLength: 50, nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "carreras",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idfacultad = table.Column<int>(nullable: false),
                    carrerra = table.Column<string>(maxLength: 100, nullable: false),
                    borrado = table.Column<bool>(nullable: false),
                    facultadesid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carreras", x => x.id);
                    table.ForeignKey(
                        name: "FK_carreras_facultades_facultadesid",
                        column: x => x.facultadesid,
                        principalTable: "facultades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "roles_permisos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rolid = table.Column<int>(nullable: false),
                    moduloid = table.Column<int>(nullable: false),
                    visualizar = table.Column<bool>(nullable: false),
                    crear = table.Column<bool>(nullable: false),
                    editar = table.Column<bool>(nullable: false),
                    borrar = table.Column<bool>(nullable: false),
                    imprimir = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles_permisos", x => x.id);
                    table.ForeignKey(
                        name: "FK_roles_permisos_modulos_moduloid",
                        column: x => x.moduloid,
                        principalTable: "modulos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_roles_permisos_roles_rolid",
                        column: x => x.rolid,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombres = table.Column<string>(maxLength: 50, nullable: false),
                    apellidos = table.Column<string>(maxLength: 50, nullable: false),
                    usuario = table.Column<string>(maxLength: 50, nullable: false),
                    clave = table.Column<string>(nullable: false),
                    rolid = table.Column<int>(nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_rolid",
                        column: x => x.rolid,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "boletas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    idusuario = table.Column<int>(nullable: false),
                    idfacultad = table.Column<int>(nullable: false),
                    idcarrera = table.Column<int>(nullable: false),
                    encargado = table.Column<string>(maxLength: 75, nullable: false),
                    materia = table.Column<string>(maxLength: 250, nullable: false),
                    detalle = table.Column<string>(type: "text", nullable: false),
                    devuelto = table.Column<bool>(nullable: false),
                    borrado = table.Column<bool>(nullable: false),
                    facultadesid = table.Column<int>(nullable: true),
                    usuariosid = table.Column<int>(nullable: true),
                    carrerasid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boletas", x => x.id);
                    table.ForeignKey(
                        name: "FK_boletas_carreras_carrerasid",
                        column: x => x.carrerasid,
                        principalTable: "carreras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_boletas_facultades_facultadesid",
                        column: x => x.facultadesid,
                        principalTable: "facultades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_boletas_usuarios_usuariosid",
                        column: x => x.usuariosid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "movimientos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    documento = table.Column<string>(maxLength: 25, nullable: false),
                    idusuario = table.Column<int>(nullable: false),
                    idproducto = table.Column<int>(nullable: false),
                    concepto = table.Column<string>(maxLength: 250, nullable: false),
                    entrada = table.Column<int>(nullable: false),
                    salida = table.Column<int>(nullable: false),
                    saldo = table.Column<int>(nullable: false),
                    borrado = table.Column<bool>(nullable: false),
                    usuariosid = table.Column<int>(nullable: true),
                    productosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientos", x => x.id);
                    table.ForeignKey(
                        name: "FK_movimientos_productos_productosId",
                        column: x => x.productosId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_movimientos_usuarios_usuariosid",
                        column: x => x.usuariosid,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "boletasdetalles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    iddetalle = table.Column<int>(nullable: false),
                    idproducto = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    borrado = table.Column<bool>(nullable: false),
                    boletasid = table.Column<int>(nullable: true),
                    ProductosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boletasdetalles", x => x.id);
                    table.ForeignKey(
                        name: "FK_boletasdetalles_productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_boletasdetalles_boletas_boletasid",
                        column: x => x.boletasid,
                        principalTable: "boletas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_boletas_carrerasid",
                table: "boletas",
                column: "carrerasid");

            migrationBuilder.CreateIndex(
                name: "IX_boletas_facultadesid",
                table: "boletas",
                column: "facultadesid");

            migrationBuilder.CreateIndex(
                name: "IX_boletas_usuariosid",
                table: "boletas",
                column: "usuariosid");

            migrationBuilder.CreateIndex(
                name: "IX_boletasdetalles_ProductosId",
                table: "boletasdetalles",
                column: "ProductosId");

            migrationBuilder.CreateIndex(
                name: "IX_boletasdetalles_boletasid",
                table: "boletasdetalles",
                column: "boletasid");

            migrationBuilder.CreateIndex(
                name: "IX_carreras_facultadesid",
                table: "carreras",
                column: "facultadesid");

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_productosId",
                table: "movimientos",
                column: "productosId");

            migrationBuilder.CreateIndex(
                name: "IX_movimientos_usuariosid",
                table: "movimientos",
                column: "usuariosid");

            migrationBuilder.CreateIndex(
                name: "IX_roles_permisos_moduloid",
                table: "roles_permisos",
                column: "moduloid");

            migrationBuilder.CreateIndex(
                name: "IX_roles_permisos_rolid",
                table: "roles_permisos",
                column: "rolid");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_rolid",
                table: "usuarios",
                column: "rolid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "boletasdetalles");

            migrationBuilder.DropTable(
                name: "movimientos");

            migrationBuilder.DropTable(
                name: "roles_permisos");

            migrationBuilder.DropTable(
                name: "boletas");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "modulos");

            migrationBuilder.DropTable(
                name: "carreras");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "facultades");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
