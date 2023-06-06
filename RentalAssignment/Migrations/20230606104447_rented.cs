using Microsoft.EntityFrameworkCore.Migrations;



#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class rented : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleID",
                table: "rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleID",
                table: "rentals");
        }
    }
}
