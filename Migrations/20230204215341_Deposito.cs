using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sorveteriaApi.Migrations
{
    /// <inheritdoc />
    public partial class Deposito : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //adiciona um deposito
            migrationBuilder.Sql("INSERT INTO Deposito (Quantidade) VALUES (0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //remove o deposito
            migrationBuilder.Sql("DELETE FROM Deposito WHERE DepositoId = 1");
        }
    }
}
