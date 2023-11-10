using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class ssjjs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d89969c-bb53-473d-8ed1-a814dcb6a9bc", "AQAAAAEAACcQAAAAEJEUUdoz6tWqDBqIuinwtBkeN/fvTm9QbN4ExiW+s3ucNpD2dkMCnL2l57SORa81Xg==", "8ac28d8a-4c12-4855-976a-739a0462e026" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test272932273937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "72e27b62-657b-41f0-9dd0-d4f9d8c3b75b", "a8405508-9ef0-49bb-97fa-55383b575dbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b606a05-b7ec-4049-97df-64f532b48c20", "AQAAAAEAACcQAAAAEJfYdShfVOfze9ZGiXUSd1KRMjG1UjEqk4upbLV86qXMcwsF7j44BmsRfmGlDk9ycA==", "661ae0f2-302b-42a4-a21a-94ee5d2b02b9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: "Test272932273937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7bfaa746-5607-40a8-9285-6592dc208e3d", "e0fb6c9e-2320-47e7-af11-5a7057858a9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "97267416-82ef-4e88-bcd6-f47063bc4b6e", "AQAAAAEAACcQAAAAEMClUGbX9UpTQ8oXkNSKneffDq23om5nc6KnfRcNv4EV8yYkxuOOemxUSdUnTq+H9w==", "26608576-7620-4ad0-9603-2c1ecac4c245" });
        }
    }
}
