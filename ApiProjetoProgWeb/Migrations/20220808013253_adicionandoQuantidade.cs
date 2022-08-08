using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjetoProgWeb.Migrations
{
    public partial class adicionandoQuantidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "quantidade",
                table: "ComandaProdutos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "quantidade",
                table: "ComandaProdutos");
        }
    }
}
