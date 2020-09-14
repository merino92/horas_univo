using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class Tablas_nuevas : Migration
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
                    fecha = table.Column<DateTime>(nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.Id);
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
                name: "boletasdetalles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Boletasid = table.Column<int>(nullable: true),
                    ProductosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_boletasdetalles", x => x.id);
                    table.ForeignKey(
                        name: "FK_boletasdetalles_boletas_Boletasid",
                        column: x => x.Boletasid,
                        principalTable: "boletas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_boletasdetalles_productos_ProductosId",
                        column: x => x.ProductosId,
                        principalTable: "productos",
                        principalColumn: "Id",
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
                name: "IX_boletasdetalles_Boletasid",
                table: "boletasdetalles",
                column: "Boletasid");

            migrationBuilder.CreateIndex(
                name: "IX_boletasdetalles_ProductosId",
                table: "boletasdetalles",
                column: "ProductosId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "boletasdetalles");

            migrationBuilder.DropTable(
                name: "movimientos");

            migrationBuilder.DropTable(
                name: "boletas");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "carreras");

            migrationBuilder.DropTable(
                name: "facultades");
        }
    }
}
