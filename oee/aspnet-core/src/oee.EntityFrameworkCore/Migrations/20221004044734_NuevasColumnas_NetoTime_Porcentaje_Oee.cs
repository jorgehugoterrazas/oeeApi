using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oee.Migrations
{
    public partial class NuevasColumnas_NetoTime_Porcentaje_Oee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NetoTime",
                table: "Oee_Porcentaje",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NetoTimeNP",
                table: "Oee_Porcentaje",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetoTime",
                table: "Oee_Porcentaje");

            migrationBuilder.DropColumn(
                name: "NetoTimeNP",
                table: "Oee_Porcentaje");
        }
    }
}
