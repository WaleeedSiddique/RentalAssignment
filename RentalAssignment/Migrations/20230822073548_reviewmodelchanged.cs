using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class reviewmodelchanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_rentals_RentalId",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_RentalId",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "reviews");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userId",
                table: "reviews");

            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_RentalId",
                table: "reviews",
                column: "RentalId");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_rentals_RentalId",
                table: "reviews",
                column: "RentalId",
                principalTable: "rentals",
                principalColumn: "RentalID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
