using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oee.Migrations
{
    public partial class Trazabilidad_Cortes_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cortes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroEmpleado = table.Column<int>(type: "int", nullable: false),
                    Atado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroUnico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NumeroEmpleadoFinal = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    Rechazos = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cortes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cortes");
        }
    }
}
