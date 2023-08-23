using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class statusfieldinrentalmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BikeModel",
                table: "vehicles");

            migrationBuilder.AddColumn<bool>(
                name: "BookingStatus",
                table: "rentals",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookingStatus",
                table: "rentals");

            migrationBuilder.AddColumn<string>(
                name: "BikeModel",
                table: "vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
