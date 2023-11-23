using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class newmihtar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "a67eb88a-da4d-4c08-94f8-0dbaff5cf26b", "AQAAAAEAACcQAAAAEL3NxJZS6qpN8ZC0yZ8pleOx9Ihn2XoMXqwn3N+G++Mxqqe6pdqV0LDAPvwWj0iQqg==", "448e60ee-9edb-4361-bd05-9f74fb31a3d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a4f9ea0-bc4a-4b9b-9a49-594875eb364b", "AQAAAAEAACcQAAAAEHUPT6OEEk3xIunhJir3dUSQTKXrleafggBlG4hLXVvNwWgOrVVJXHKSKpUqrvdGXg==", "2ed73faa-b325-49c1-b1a6-bc8044191621" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e007b8bc-739c-4fa9-85e3-c2afcce63990", "AQAAAAEAACcQAAAAEN/0hjEslHi1uAku77bWC63dT4IN9NKEOGgR2KtOQdj336gssykDiWTUihDQKz9Svw==", "eb56e1e6-780a-4524-a8a6-6a3024b911dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0c8bc31-699a-4b6b-976b-4dbfd342b61b", "AQAAAAEAACcQAAAAEDHdbUQDQWZHLpNMTxyDvQ5RdDbTEysotLXTOizLipFQ8XuPi+hUGAIODofUZ8ioug==", "f8d0722f-9209-4f59-a3d4-f8c999066148" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "IsApproved", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "Test272932273937898-329332ndyvyuhvjjhf8e4", 0, "8f5f31f6-264b-47af-a14c-939757b88f81", "Test2@gmail.com", true, true, false, null, "TEST2@GMAIL.COM", "TEST2USER", null, null, false, "f3a79fc5-614b-4354-a75b-7cddc3381330", false, "Test2User" });
        }
    }
}
