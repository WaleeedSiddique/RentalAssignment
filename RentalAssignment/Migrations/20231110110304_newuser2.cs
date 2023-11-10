using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class newuser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8da606de-8622-4ff0-be91-d072708ceb12", "AQAAAAEAACcQAAAAEGjq5zFZ/KSeiVOfHi+xexSJfd29ZMUPJFxcqMdqjWItF0F4U5daILdeNfsIG+LFZA==", "cca5a3ca-55f8-4f1c-be24-c2da4c95fe35" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97267416-82ef-4e88-bcd6-f47063bc4b6e", "AQAAAAEAACcQAAAAEMClUGbX9UpTQ8oXkNSKneffDq23om5nc6KnfRcNv4EV8yYkxuOOemxUSdUnTq+H9w==", "26608576-7620-4ad0-9603-2c1ecac4c245" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsApproved", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "Test272932273937898-329332ndyvyuhvjjhf8e4", 0, "7bfaa746-5607-40a8-9285-6592dc208e3d", "Test2@gmail.com", true, true, false, null, "TEST2@GMAIL.COM", "TEST2USER", null, null, false, "e0fb6c9e-2320-47e7-af11-5a7057858a9c", false, "Test2User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test272932273937898-329332ndyvyuhvjjhf8e4");

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
    }
}
