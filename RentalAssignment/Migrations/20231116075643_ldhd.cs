using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class ldhd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: "Test272932273937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8f5f31f6-264b-47af-a14c-939757b88f81", "f3a79fc5-614b-4354-a75b-7cddc3381330" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0c8bc31-699a-4b6b-976b-4dbfd342b61b", "AQAAAAEAACcQAAAAEDHdbUQDQWZHLpNMTxyDvQ5RdDbTEysotLXTOizLipFQ8XuPi+hUGAIODofUZ8ioug==", "f8d0722f-9209-4f59-a3d4-f8c999066148" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
