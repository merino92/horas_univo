using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class Tablas_arreglos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boletasdetalles_boletas_Boletasid",
                table: "boletasdetalles");

            migrationBuilder.RenameColumn(
                name: "Boletasid",
                table: "boletasdetalles",
                newName: "boletasid");

            migrationBuilder.RenameIndex(
                name: "IX_boletasdetalles_Boletasid",
                table: "boletasdetalles",
                newName: "IX_boletasdetalles_boletasid");

            migrationBuilder.AddColumn<bool>(
                name: "borrado",
                table: "movimientos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "borrado",
                table: "boletasdetalles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "cantidad",
                table: "boletasdetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "iddetalle",
                table: "boletasdetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idproducto",
                table: "boletasdetalles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_boletasdetalles_boletas_boletasid",
                table: "boletasdetalles",
                column: "boletasid",
                principalTable: "boletas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_boletasdetalles_boletas_boletasid",
                table: "boletasdetalles");

            migrationBuilder.DropColumn(
                name: "borrado",
                table: "movimientos");

            migrationBuilder.DropColumn(
                name: "borrado",
                table: "boletasdetalles");

            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "boletasdetalles");

            migrationBuilder.DropColumn(
                name: "iddetalle",
                table: "boletasdetalles");

            migrationBuilder.DropColumn(
                name: "idproducto",
                table: "boletasdetalles");

            migrationBuilder.RenameColumn(
                name: "boletasid",
                table: "boletasdetalles",
                newName: "Boletasid");

            migrationBuilder.RenameIndex(
                name: "IX_boletasdetalles_boletasid",
                table: "boletasdetalles",
                newName: "IX_boletasdetalles_Boletasid");

            migrationBuilder.AddForeignKey(
                name: "FK_boletasdetalles_boletas_Boletasid",
                table: "boletasdetalles",
                column: "Boletasid",
                principalTable: "boletas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
