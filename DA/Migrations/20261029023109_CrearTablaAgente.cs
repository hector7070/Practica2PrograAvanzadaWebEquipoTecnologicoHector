using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DA.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaAgente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agentes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacidadMaxima = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AgenteId",
                table: "Tickets",
                column: "AgenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Agentes_AgenteId",
                table: "Tickets",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Agentes_AgenteId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Agentes");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AgenteId",
                table: "Tickets");
        }
    }
}
