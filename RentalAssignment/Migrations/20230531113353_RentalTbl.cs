using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class RentalTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "rentals",
                columns: table => new
                {
                    RentalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RentalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RentalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pickup = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dropoff = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentals", x => x.RentalID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rentals");
        }
    }
}
