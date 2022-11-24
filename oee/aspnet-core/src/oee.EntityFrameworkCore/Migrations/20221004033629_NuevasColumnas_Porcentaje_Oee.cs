using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oee.Migrations
{
    public partial class NuevasColumnas_Porcentaje_Oee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Availability_Porcentaje",
                table: "Oee_Porcentaje",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Oee_Porcentaje",
                table: "Oee_Porcentaje",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Performance_Porcentaje",
                table: "Oee_Porcentaje",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Quality_Porcentaje",
                table: "Oee_Porcentaje",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability_Porcentaje",
                table: "Oee_Porcentaje");

            migrationBuilder.DropColumn(
                name: "Oee_Porcentaje",
                table: "Oee_Porcentaje");

            migrationBuilder.DropColumn(
                name: "Performance_Porcentaje",
                table: "Oee_Porcentaje");

            migrationBuilder.DropColumn(
                name: "Quality_Porcentaje",
                table: "Oee_Porcentaje");
        }
    }
}
