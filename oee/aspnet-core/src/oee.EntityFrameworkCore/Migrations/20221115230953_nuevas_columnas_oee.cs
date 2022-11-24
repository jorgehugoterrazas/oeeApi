using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oee.Migrations
{
    public partial class nuevas_columnas_oee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Asociados",
                table: "Oee_Porcentaje",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TiempoCiclo",
                table: "Oee_Porcentaje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asociados",
                table: "Oee_Porcentaje");

            migrationBuilder.DropColumn(
                name: "TiempoCiclo",
                table: "Oee_Porcentaje");
        }
    }
}
