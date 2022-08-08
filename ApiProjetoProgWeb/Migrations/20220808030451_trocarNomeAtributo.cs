using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiProjetoProgWeb.Migrations
{
    public partial class trocarNomeAtributo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idUsuario",
                table: "Comandas",
                newName: "id");

            migrationBuilder.UpdateData(
                table: "ComandaProdutos",
                keyColumn: "id",
                keyValue: 1,
                column: "quantidade",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ComandaProdutos",
                keyColumn: "id",
                keyValue: 2,
                column: "quantidade",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ComandaProdutos",
                keyColumn: "id",
                keyValue: 3,
                column: "quantidade",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Comandas",
                newName: "idUsuario");

            migrationBuilder.UpdateData(
                table: "ComandaProdutos",
                keyColumn: "id",
                keyValue: 1,
                column: "quantidade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ComandaProdutos",
                keyColumn: "id",
                keyValue: 2,
                column: "quantidade",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ComandaProdutos",
                keyColumn: "id",
                keyValue: 3,
                column: "quantidade",
                value: 0);
        }
    }
}
