using Microsoft.EntityFrameworkCore.Migrations;

namespace Minha1Conexao.Data.Migrations
{
    public partial class addColumnPerfilUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Perfil",
                table: "Usuario",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Perfil",
                table: "Usuario");
        }
    }
}
