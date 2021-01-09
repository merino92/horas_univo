using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class codigo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boletacarreras_boletas_idboleta",
                table: "Boletacarreras");

            migrationBuilder.DropForeignKey(
                name: "FK_Boletacarreras_carreras_idcarrera",
                table: "Boletacarreras");

            migrationBuilder.DropForeignKey(
                name: "FK_Boletamaterias_boletas_idboleta",
                table: "Boletamaterias");

            migrationBuilder.DropForeignKey(
                name: "FK_Boletamaterias_Materias_idmateria",
                table: "Boletamaterias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Materias",
                table: "Materias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boletamaterias",
                table: "Boletamaterias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boletacarreras",
                table: "Boletacarreras");

            migrationBuilder.RenameTable(
                name: "Materias",
                newName: "materias");

            migrationBuilder.RenameTable(
                name: "Boletamaterias",
                newName: "boletamaterias");

            migrationBuilder.RenameTable(
                name: "Boletacarreras",
                newName: "boletacarreras");

            migrationBuilder.RenameIndex(
                name: "IX_Boletamaterias_idmateria",
                table: "boletamaterias",
                newName: "IX_boletamaterias_idmateria");

            migrationBuilder.RenameIndex(
                name: "IX_Boletamaterias_idboleta",
                table: "boletamaterias",
                newName: "IX_boletamaterias_idboleta");

            migrationBuilder.RenameIndex(
                name: "IX_Boletacarreras_idcarrera",
                table: "boletacarreras",
                newName: "IX_boletacarreras_idcarrera");

            migrationBuilder.RenameIndex(
                name: "IX_Boletacarreras_idboleta",
                table: "boletacarreras",
                newName: "IX_boletacarreras_idboleta");

            migrationBuilder.AddColumn<string>(
                name: "codigo",
                table: "boletas",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "parcial",
                table: "boletas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_materias",
                table: "materias",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boletamaterias",
                table: "boletamaterias",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boletacarreras",
                table: "boletacarreras",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_boletacarreras_boletas_idboleta",
                table: "boletacarreras",
                column: "idboleta",
                principalTable: "boletas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_boletacarreras_carreras_idcarrera",
                table: "boletacarreras",
                column: "idcarrera",
                principalTable: "carreras",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_boletamaterias_boletas_idboleta",
                table: "boletamaterias",
                column: "idboleta",
                principalTable: "boletas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_boletamaterias_materias_idmateria",
                table: "boletamaterias",
                column: "idmateria",
                principalTable: "materias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boletacarreras_boletas_idboleta",
                table: "boletacarreras");

            migrationBuilder.DropForeignKey(
                name: "FK_boletacarreras_carreras_idcarrera",
                table: "boletacarreras");

            migrationBuilder.DropForeignKey(
                name: "FK_boletamaterias_boletas_idboleta",
                table: "boletamaterias");

            migrationBuilder.DropForeignKey(
                name: "FK_boletamaterias_materias_idmateria",
                table: "boletamaterias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_materias",
                table: "materias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boletamaterias",
                table: "boletamaterias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boletacarreras",
                table: "boletacarreras");

            migrationBuilder.DropColumn(
                name: "codigo",
                table: "boletas");

            migrationBuilder.DropColumn(
                name: "parcial",
                table: "boletas");

            migrationBuilder.RenameTable(
                name: "materias",
                newName: "Materias");

            migrationBuilder.RenameTable(
                name: "boletamaterias",
                newName: "Boletamaterias");

            migrationBuilder.RenameTable(
                name: "boletacarreras",
                newName: "Boletacarreras");

            migrationBuilder.RenameIndex(
                name: "IX_boletamaterias_idmateria",
                table: "Boletamaterias",
                newName: "IX_Boletamaterias_idmateria");

            migrationBuilder.RenameIndex(
                name: "IX_boletamaterias_idboleta",
                table: "Boletamaterias",
                newName: "IX_Boletamaterias_idboleta");

            migrationBuilder.RenameIndex(
                name: "IX_boletacarreras_idcarrera",
                table: "Boletacarreras",
                newName: "IX_Boletacarreras_idcarrera");

            migrationBuilder.RenameIndex(
                name: "IX_boletacarreras_idboleta",
                table: "Boletacarreras",
                newName: "IX_Boletacarreras_idboleta");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Materias",
                table: "Materias",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boletamaterias",
                table: "Boletamaterias",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boletacarreras",
                table: "Boletacarreras",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Boletacarreras_boletas_idboleta",
                table: "Boletacarreras",
                column: "idboleta",
                principalTable: "boletas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletacarreras_carreras_idcarrera",
                table: "Boletacarreras",
                column: "idcarrera",
                principalTable: "carreras",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletamaterias_boletas_idboleta",
                table: "Boletamaterias",
                column: "idboleta",
                principalTable: "boletas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletamaterias_Materias_idmateria",
                table: "Boletamaterias",
                column: "idmateria",
                principalTable: "Materias",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
