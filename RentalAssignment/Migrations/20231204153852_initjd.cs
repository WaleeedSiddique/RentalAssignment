using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class initjd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "206bc870-cdc8-4bce-8e5e-fdb0b617acd0", "AQAAAAEAACcQAAAAEA0Y+uHb6JIuSKgdQ4H1FPHeDZ5zThvJQr+dLUBJauPpO4De9GkR9HnuB3q8Gi6SmA==", "b309a011-3aaa-40ad-a845-1fec85f48d88" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31233a56-2fe5-4e7b-9ef9-22a2cfba13ed", "AQAAAAEAACcQAAAAELeOpTuK6a5lFniRCdr22sSQq+6IrSidazmEMNTcrKinAj8qUBRWNhH1g0kW9fZ01g==", "136c37a7-a237-4dd2-a0a2-feb287ef0936" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test27293wdqwdqw73937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3338bc65-9c4b-45ab-8e37-e33eb776852b", "b26b9f8d-1b5e-45fe-a6bd-0a14b61d4383" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8bf78b4-c91b-4795-a08a-6eefd5eed2a4", "AQAAAAEAACcQAAAAEFnt5YmCRtOBM1JYD3kxeYEBa/iKz5EsSK0KoSS85Yid7/abFOVV8eeXgx3O3/IfYw==", "6db86271-575c-4f8b-8642-47f63762ce91" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b41c19d1-94b2-4881-8a94-f5e92b0c2795", "AQAAAAEAACcQAAAAEEwASEo/WiBf1dQ3krdMHvrRayfa/RSWjfK5QeLMKocU2P6kstU9eIP8b0djna5FOg==", "18bc73f3-9291-4709-afda-35884f6a61c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test27293wdqwdqw73937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "70fe8dbf-f72c-4279-a7ae-93fc635a9b71", "e88fed4f-12c7-47b3-b9f2-5ec10913fc4c" });
        }
    }
}
