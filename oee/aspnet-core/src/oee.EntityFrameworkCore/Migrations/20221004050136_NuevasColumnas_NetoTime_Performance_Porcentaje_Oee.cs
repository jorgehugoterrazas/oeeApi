using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oee.Migrations
{
    public partial class NuevasColumnas_NetoTime_Performance_Porcentaje_Oee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NetoTimeNP_Performance",
                table: "Oee_Porcentaje",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetoTimeNP_Performance",
                table: "Oee_Porcentaje");
        }
    }
}
