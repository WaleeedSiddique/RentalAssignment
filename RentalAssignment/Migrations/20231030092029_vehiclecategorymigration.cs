using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class vehiclecategorymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleCategoryId",
                table: "vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "616a29de-806a-4213-8003-9a80bfdd660a", "AQAAAAEAACcQAAAAEN9PSBXW0gIkwpF2ylFeNjeEZHkjmsqyEJXR5GNxvNxzJwA14P+kkRJWdyQ4qHjIng==", "7c2adfc5-848a-4cc3-b617-7667b32a26db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "edb3860c-2093-484f-ae28-9157cd063347", "AQAAAAEAACcQAAAAEEuGfWBQDzm7JJNvf3SYrcKVa6mrNgDmh3yxxms2tQ3K2gRdb6WcIyn8v/IQJLHxSw==", "8d1e058b-54bb-4689-b001-53e130e4a08e" });

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_VehicleCategoryId",
                table: "vehicles",
                column: "VehicleCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_vehicles_VehicleCategories_VehicleCategoryId",
                table: "vehicles",
                column: "VehicleCategoryId",
                principalTable: "VehicleCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vehicles_VehicleCategories_VehicleCategoryId",
                table: "vehicles");

            migrationBuilder.DropIndex(
                name: "IX_vehicles_VehicleCategoryId",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleCategoryId",
                table: "vehicles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e92dfa4d-30ba-4796-abc6-252429e16138", "AQAAAAEAACcQAAAAEOeZ+QpU7Un5zwHXHdLDcdA6w8vjgSss7NtcwT/quTWXwkOM6FYxEYZ5bdUnLuUucw==", "877f3829-1c03-476b-9cf9-7ec9a619149d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96ad5e72-3db0-472c-a5ad-af611188083f", "AQAAAAEAACcQAAAAEFlAeE25f7m9JCr2RnHaXU9lZNgkbLqFeQlh1nQhVNp/kGe3JC3c44ZqnOsG8zbBsg==", "de3a6b5a-f362-45e3-acca-9fd66b1bd132" });
        }
    }
}
