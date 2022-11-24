using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oee.Migrations
{
    public partial class Add_Tabla_Oee_Porcentaje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oee_Porcentaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TurnoId = table.Column<int>(type: "int", nullable: false),
                    NumeroParte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalReales = table.Column<int>(type: "int", nullable: false),
                    OE_Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    GAP_Pzas = table.Column<int>(type: "int", nullable: false),
                    GAP_Mins = table.Column<int>(type: "int", nullable: false),
                    TiempoMuerto = table.Column<int>(type: "int", nullable: false),
                    Programado = table.Column<int>(type: "int", nullable: false),
                    DescripcionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oee_Porcentaje", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oee_Porcentaje");
        }
    }
}
