using Microsoft.EntityFrameworkCore.Migrations;

namespace FireBird.API.Migrations
{
    public partial class ChangeColumnNameHeigth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Persons");

            migrationBuilder.AddColumn<double>(
                name: "Heigth",
                table: "Persons",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heigth",
                table: "Persons");

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Persons",
                type: "DOUBLE PRECISION",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
