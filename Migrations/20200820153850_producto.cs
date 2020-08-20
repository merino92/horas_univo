using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class producto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "movimientos",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(nullable: false),
                    documento = table.Column<string>(maxLength: 25, nullable: false),
                    usuario = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movimientos", x => x.id);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movimientos");

            migrationBuilder.DropTable(
                name: "productos");
        }
    }
}
