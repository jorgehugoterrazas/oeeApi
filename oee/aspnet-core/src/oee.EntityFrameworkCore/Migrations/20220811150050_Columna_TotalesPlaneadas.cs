using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oee.Migrations
{
    public partial class Columna_TotalesPlaneadas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPlaneadas",
                table: "Oee_Porcentaje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPlaneadas",
                table: "Oee_Porcentaje");
        }
    }
}
