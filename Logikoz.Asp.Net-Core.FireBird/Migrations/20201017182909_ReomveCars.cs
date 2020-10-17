using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FireBird.API.Migrations
{
    public partial class ReomveCars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<Guid>(type: "CHAR(16) CHARACTER SET OCTETS", nullable: false),
                    Brand = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false),
                    Model = table.Column<string>(type: "BLOB SUB_TYPE TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });
        }
    }
}
