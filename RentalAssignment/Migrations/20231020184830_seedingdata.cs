using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class seedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d59400c-7359-4079-bd8f-31cfb999ab112c7");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3d05f4f9-c443-489a-9672-82f3aa518999e70", "7d59400c-7359-4079-bd8f-31cfb999ab112c7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin34343nfefnje9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user3838378348");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d05f4f9-c443-489a-9672-82f3aa518999e70");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d05f4f9-c443-489a-9672-82f3aa518999e70", "8dc19c25-5a32-44d9-9322-193ad5c19756", "Admin", "Admin" },
                    { "7d59400c-7359-4079-bd8f-31cfb999ab112c7", "9f008284-a4b2-4e4f-a5cb-9f4aa21b9f9d", "Customer", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsApproved", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "admin34343nfefnje9", 0, "5d79051d-6a77-4b9c-8981-6194130cb5de", "Admin@gmail.com", true, true, false, null, "Admin@gmail.com", "Admin", "AQAAAAEAACcQAAAAENhosZQs1PAe4nqAMPFQuF8ZQmKJSv5RhLNxfbbzEvWk507gciAOMMtG6gjuTtr7/g==", null, false, "", false, "Admin" },
                    { "user3838378348", 0, "f2cef5a7-86d0-4643-84e9-42a5c21737b1", "Testuser@gmail.com", true, true, false, null, "User@gmail.com", "Test User", "AQAAAAEAACcQAAAAEDMY8ghaOSo393AZMrPry4EwJoFZAkcIHbZN0gdlqD/AGpJCYQLmtK19FSMjT9V3ig==", null, false, "", false, "TestUser" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3d05f4f9-c443-489a-9672-82f3aa518999e70", "7d59400c-7359-4079-bd8f-31cfb999ab112c7" });
        }
    }
}
