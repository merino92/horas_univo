using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class facultades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carreras_facultades_facultadesid",
                table: "carreras");

            migrationBuilder.DropIndex(
                name: "IX_carreras_facultadesid",
                table: "carreras");

            migrationBuilder.DropColumn(
                name: "facultadesid",
                table: "carreras");

            migrationBuilder.CreateIndex(
                name: "IX_carreras_idfacultad",
                table: "carreras",
                column: "idfacultad");

            migrationBuilder.AddForeignKey(
                name: "FK_carreras_facultades_idfacultad",
                table: "carreras",
                column: "idfacultad",
                principalTable: "facultades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carreras_facultades_idfacultad",
                table: "carreras");

            migrationBuilder.DropIndex(
                name: "IX_carreras_idfacultad",
                table: "carreras");

            migrationBuilder.AddColumn<int>(
                name: "facultadesid",
                table: "carreras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_carreras_facultadesid",
                table: "carreras",
                column: "facultadesid");

            migrationBuilder.AddForeignKey(
                name: "FK_carreras_facultades_facultadesid",
                table: "carreras",
                column: "facultadesid",
                principalTable: "facultades",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
