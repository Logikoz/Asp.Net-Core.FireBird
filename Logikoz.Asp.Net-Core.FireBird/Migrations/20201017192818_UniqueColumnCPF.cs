using Microsoft.EntityFrameworkCore.Migrations;

namespace FireBird.API.Migrations
{
    public partial class UniqueColumnCPF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Persons_CPF",
                table: "Persons",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Persons_CPF",
                table: "Persons");
        }
    }
}
