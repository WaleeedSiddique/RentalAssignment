using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class changeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test27293wdqwdqw73937898-329332ndyvyuhvjjhf8e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50b18d2d-17bf-439a-b880-6aa97760c3c3", "AQAAAAEAACcQAAAAEGTpVrN5oWmTdHInrot8s16uNf9PKry5uMDmgPxdnU0x9V3+aMOXNIy1e/KGrrzkHQ==", "ad0e6a96-c2d2-4f69-a4bd-e26b64eb863e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3023a7b-0734-4581-bd9d-aebe6e0aec5d", "AQAAAAEAACcQAAAAELtI2awXnL+vf7zOY/LP/zhpUbn9/mY4PvLC/o70S1wTA6a3VmnOIyU97FZTXsmMVg==", "29919a17-89f2-4576-b807-005dc504d71a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "442b5e10-c73c-4897-9cd4-ddc19d439c0f", "AQAAAAEAACcQAAAAECMh4fVagQQdymjmnyJsGA/KstTZdmBBFaqf+mVcQFvIzhDUnOeBrq9j9fPVPLeB9Q==", "2d192553-b843-42eb-a425-1b572120f714" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd936e45-f287-42ac-acfe-1ae5f104a46c", "AQAAAAEAACcQAAAAEPUX4AMrp78NN7j76HHkM/NAUxP8uSBkn8JH3eAObJz9u738BfiI2YhUDWUKV5HxWg==", "79bf5fad-905f-49a6-bf76-801a5a21e0a1" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsApproved", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "Test27293wdqwdqw73937898-329332ndyvyuhvjjhf8e4", 0, "2ae5e7d1-8079-48df-be33-584a539cb3f3", "Test2@gmail.com", true, true, false, null, "TEST2@GMAIL.COM", "TESTUSER2", null, null, false, "d7ed2a7f-643c-4e84-94e2-8b6ee5407781", false, "TestUser2" });
        }
    }
}
