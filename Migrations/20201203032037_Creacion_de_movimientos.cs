using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class Creacion_de_movimientos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "requisiciones",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    idusuario = table.Column<int>(nullable: false),
                    detalle = table.Column<string>(maxLength: 25, nullable: false),
                    entrada = table.Column<bool>(nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requisiciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_requisiciones_usuarios_idusuario",
                        column: x => x.idusuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "requisiciondetalles",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idproducto = table.Column<int>(nullable: false),
                    idrequisicion = table.Column<int>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    borrado = table.Column<bool>(nullable: false),
                    idrequsicion = table.Column<int>(nullable: true),
                    Movimientosid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_requisiciondetalles", x => x.id);
                    table.ForeignKey(
                        name: "FK_requisiciondetalles_movimientos_Movimientosid",
                        column: x => x.Movimientosid,
                        principalTable: "movimientos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_requisiciondetalles_productos_idproducto",
                        column: x => x.idproducto,
                        principalTable: "productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_requisiciondetalles_requisiciones_idrequsicion",
                        column: x => x.idrequsicion,
                        principalTable: "requisiciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_requisiciondetalles_Movimientosid",
                table: "requisiciondetalles",
                column: "Movimientosid");

            migrationBuilder.CreateIndex(
                name: "IX_requisiciondetalles_idproducto",
                table: "requisiciondetalles",
                column: "idproducto");

            migrationBuilder.CreateIndex(
                name: "IX_requisiciondetalles_idrequsicion",
                table: "requisiciondetalles",
                column: "idrequsicion");

            migrationBuilder.CreateIndex(
                name: "IX_requisiciones_idusuario",
                table: "requisiciones",
                column: "idusuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "requisiciondetalles");

            migrationBuilder.DropTable(
                name: "requisiciones");
        }
    }
}
