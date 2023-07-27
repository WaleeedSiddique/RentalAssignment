using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class AddedCategoryControllerModelCrudView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rentals_VehicleID",
                table: "rentals",
                column: "VehicleID");

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_vehicles_VehicleID",
                table: "rentals",
                column: "VehicleID",
                principalTable: "vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_vehicles_VehicleID",
                table: "rentals");

            migrationBuilder.DropTable(
                name: "VehicleCategories");

            migrationBuilder.DropIndex(
                name: "IX_rentals_VehicleID",
                table: "rentals");
        }
    }
}
