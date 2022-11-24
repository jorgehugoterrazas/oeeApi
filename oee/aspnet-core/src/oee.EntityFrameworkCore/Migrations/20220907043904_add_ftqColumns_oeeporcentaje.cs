using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace oee.Migrations
{
    public partial class add_ftqColumns_oeeporcentaje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DescripcionFTQ",
                table: "Oee_Porcentaje",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ftq",
                table: "Oee_Porcentaje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DescripcionFTQ",
                table: "Oee_Porcentaje");

            migrationBuilder.DropColumn(
                name: "Ftq",
                table: "Oee_Porcentaje");
        }
    }
}
