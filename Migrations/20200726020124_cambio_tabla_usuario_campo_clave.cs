using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class cambio_tabla_usuario_campo_clave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "clave",
                table: "usuarios",
                type: "text",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
