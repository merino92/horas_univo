using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class Creacion_de_tablas_bolesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idcarrera",
                table: "boletas");

            migrationBuilder.DropColumn(
                name: "idfacultad",
                table: "boletas");

            migrationBuilder.DropColumn(
                name: "materia",
                table: "boletas");

            migrationBuilder.AlterColumn<string>(
                name: "detalle",
                table: "boletas",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Boletacarreras",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idboleta = table.Column<int>(nullable: false),
                    idcarrera = table.Column<int>(nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletacarreras", x => x.id);
                    table.ForeignKey(
                        name: "FK_Boletacarreras_boletas_idboleta",
                        column: x => x.idboleta,
                        principalTable: "boletas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boletacarreras_carreras_idcarrera",
                        column: x => x.idcarrera,
                        principalTable: "carreras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    materia = table.Column<string>(maxLength: 100, nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Boletamaterias",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idboleta = table.Column<int>(nullable: false),
                    idmateria = table.Column<int>(nullable: false),
                    borrado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletamaterias", x => x.id);
                    table.ForeignKey(
                        name: "FK_Boletamaterias_boletas_idboleta",
                        column: x => x.idboleta,
                        principalTable: "boletas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Boletamaterias_Materias_idmateria",
                        column: x => x.idmateria,
                        principalTable: "Materias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Boletacarreras_idboleta",
                table: "Boletacarreras",
                column: "idboleta");

            migrationBuilder.CreateIndex(
                name: "IX_Boletacarreras_idcarrera",
                table: "Boletacarreras",
                column: "idcarrera");

            migrationBuilder.CreateIndex(
                name: "IX_Boletamaterias_idboleta",
                table: "Boletamaterias",
                column: "idboleta");

            migrationBuilder.CreateIndex(
                name: "IX_Boletamaterias_idmateria",
                table: "Boletamaterias",
                column: "idmateria");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boletacarreras");

            migrationBuilder.DropTable(
                name: "Boletamaterias");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.AlterColumn<string>(
                name: "detalle",
                table: "boletas",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AddColumn<int>(
                name: "idcarrera",
                table: "boletas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idfacultad",
                table: "boletas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "materia",
                table: "boletas",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
