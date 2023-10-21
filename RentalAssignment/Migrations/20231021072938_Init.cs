using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsApproved", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "Test2729373937898-329332ndjhf8e4", 0, "be8f9995-f889-4cd4-ae04-1edd3777862a", "Test@gmail.com", false, true, false, null, null, null, "AQAAAAEAACcQAAAAEGp+Rr7N6l3PFwMLIVjv7WFlFwD1dYgYhbyIh+ZYqrMiTCFaFQAaxjfDidzlwSkm6w==", null, false, "064b295b-c6a5-4fad-aa7b-0fd0c0794844", false, "TestUser" });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
