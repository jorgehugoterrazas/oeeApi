using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oee.Migrations
{
    public partial class add_tipoIncidencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Cortes");

            migrationBuilder.DropTable(
                name: "DescripcionFallas");

            migrationBuilder.DropTable(
                name: "Oee_Porcentaje");

            migrationBuilder.DropTable(
                name: "TiempoCiclos");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.CreateTable(
                name: "TipoIncidencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoIncidencias", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TipoIncidencias");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cortes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: true),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Maquina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroEmpleado = table.Column<int>(type: "int", nullable: false),
                    NumeroEmpleadoFinal = table.Column<int>(type: "int", nullable: true),
                    NumeroParte = table.Column<int>(type: "int", nullable: true),
                    NumeroUnico = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rechazos = table.Column<int>(type: "int", nullable: true),
                    Subensamble = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cortes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DescripcionFallas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Modo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescripcionFallas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Oee_Porcentaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asociados = table.Column<int>(type: "int", nullable: false),
                    Availability_Porcentaje = table.Column<double>(type: "float", nullable: true),
                    DescripcionFTQ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescripcionId = table.Column<int>(type: "int", nullable: false),
                    DescripcionTM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ftq = table.Column<int>(type: "int", nullable: false),
                    GAP_Mins = table.Column<int>(type: "int", nullable: false),
                    GAP_Pzas = table.Column<int>(type: "int", nullable: false),
                    HoraFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NetoTime = table.Column<int>(type: "int", nullable: true),
                    NetoTimeNP = table.Column<int>(type: "int", nullable: true),
                    NetoTimeNP_Performance = table.Column<int>(type: "int", nullable: true),
                    NumeroParte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OE_Porcentaje = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Oee_Porcentaje = table.Column<double>(type: "float", nullable: true),
                    Performance_Porcentaje = table.Column<double>(type: "float", nullable: true),
                    Programado = table.Column<int>(type: "int", nullable: false),
                    Quality_Porcentaje = table.Column<double>(type: "float", nullable: true),
                    TiempoCiclo = table.Column<int>(type: "int", nullable: false),
                    TiempoMuerto = table.Column<int>(type: "int", nullable: false),
                    TotalPlaneadas = table.Column<int>(type: "int", nullable: false),
                    TotalReales = table.Column<int>(type: "int", nullable: false),
                    TurnoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oee_Porcentaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiempoCiclos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerodeParte = table.Column<int>(type: "int", nullable: false),
                    Programa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiempoEnSegundos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiempoCiclos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.Id);
                });
        }
    }
}
