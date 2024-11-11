using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NikosPizza.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class initial12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tamaño",
                schema: "pizza",
                table: "Pizzas");

            migrationBuilder.AddColumn<Guid>(
                name: "TamanioPizzaId",
                schema: "pizza",
                table: "Pizzas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TamanioPizzas",
                schema: "pizza",
                columns: table => new
                {
                    TamanioPizzaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TamanioPizzas", x => x.TamanioPizzaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_TamanioPizzaId",
                schema: "pizza",
                table: "Pizzas",
                column: "TamanioPizzaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_TamanioPizzas_TamanioPizzaId",
                schema: "pizza",
                table: "Pizzas",
                column: "TamanioPizzaId",
                principalSchema: "pizza",
                principalTable: "TamanioPizzas",
                principalColumn: "TamanioPizzaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_TamanioPizzas_TamanioPizzaId",
                schema: "pizza",
                table: "Pizzas");

            migrationBuilder.DropTable(
                name: "TamanioPizzas",
                schema: "pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_TamanioPizzaId",
                schema: "pizza",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "TamanioPizzaId",
                schema: "pizza",
                table: "Pizzas");

            migrationBuilder.AddColumn<string>(
                name: "Tamaño",
                schema: "pizza",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
