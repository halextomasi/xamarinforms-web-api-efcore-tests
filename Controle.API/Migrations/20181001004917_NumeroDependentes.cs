using Microsoft.EntityFrameworkCore.Migrations;

namespace Controle.API.Migrations
{
    public partial class NumeroDependentes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumeroDependentes",
                table: "Contribuintes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumeroDependentes",
                table: "Contribuintes");
        }
    }
}
