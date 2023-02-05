using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sorveteriaApi.Migrations
{
    /// <inheritdoc />
    public partial class TabelaProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produto_Deposito_DepositoId",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "Produtos");

            migrationBuilder.RenameIndex(
                name: "IX_Produto_DepositoId",
                table: "Produtos",
                newName: "IX_Produtos_DepositoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Deposito_DepositoId",
                table: "Produtos",
                column: "DepositoId",
                principalTable: "Deposito",
                principalColumn: "DepositoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Deposito_DepositoId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produtos",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Produtos",
                newName: "Produto");

            migrationBuilder.RenameIndex(
                name: "IX_Produtos_DepositoId",
                table: "Produto",
                newName: "IX_Produto_DepositoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produto_Deposito_DepositoId",
                table: "Produto",
                column: "DepositoId",
                principalTable: "Deposito",
                principalColumn: "DepositoId");
        }
    }
}
