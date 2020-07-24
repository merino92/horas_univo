using Microsoft.EntityFrameworkCore.Migrations;

namespace univo.Migrations
{
    public partial class update_usuariostbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "borrado",
                table: "usuarios",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "borrado",
                table: "usuarios");
        }
    }
}
