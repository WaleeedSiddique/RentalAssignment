using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class recthe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a0435d3-a280-4580-92e6-d43000097443", "AQAAAAEAACcQAAAAEO+L4eSkyQitw7Kb7Q1g4amjZa7/LDPAJWkH12VF6wemk1iLR+tNjiAlcWlywCBkew==", "b99b68d5-9a02-4203-b26e-e5a19edcd24c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1fae73ed-096e-4aac-bbde-58b169cb15e0", "AQAAAAEAACcQAAAAEJamTlRH9iSb0qFTPgnLJTwh21Yhm+7twfliK5w76YyF+yYto6fw9GIADZ+ZbbDO4A==", "71826776-8c30-4607-a96e-edab27f8c5c2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
