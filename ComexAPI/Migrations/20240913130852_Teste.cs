using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ComexAPI.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_enderecoId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "enderecoId",
                table: "Clientes",
                newName: "EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_enderecoId",
                table: "Clientes",
                newName: "IX_Clientes_EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_EnderecoId",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "EnderecoId",
                table: "Clientes",
                newName: "enderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_EnderecoId",
                table: "Clientes",
                newName: "IX_Clientes_enderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_enderecoId",
                table: "Clientes",
                column: "enderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
