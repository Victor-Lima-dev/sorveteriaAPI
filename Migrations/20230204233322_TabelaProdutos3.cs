﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sorveteriaApi.Migrations
{
    /// <inheritdoc />
    public partial class TabelaProdutos3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Produtos");
        }
    }
}
