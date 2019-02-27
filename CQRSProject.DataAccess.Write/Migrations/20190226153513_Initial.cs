using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CQRSProject.DataAccess.Write.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(maxLength: 255, nullable: false),
                    Latitude = table.Column<double>(maxLength: 255, nullable: false),
                    Longitude = table.Column<double>(maxLength: 255, nullable: false),
                    Height = table.Column<double>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLocations");
        }
    }
}
