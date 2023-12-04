using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class navprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "rentals",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Admin2729083033937898-329332nduyvugjvjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f47b5232-056f-4ced-94ec-fef749f7fea9", "AQAAAAEAACcQAAAAEDOZV1raA1951perNueWS91bDUXtDHg6evV2KFADWtFxSA+DdYgoLxhDccAgtjUQ6A==", "7a9e0fdb-5399-4204-933a-23f4b4787595" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test2729373937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbae899a-a1f5-41e9-b001-c4e6e0cf38fa", "AQAAAAEAACcQAAAAEMl0QCdtRdiq4yj63mEZA3s1sY1B9fCv+kAGnp/ylisbVXoZ2YJoQfy6zzvvkZlprQ==", "7acdd99c-2b57-4fd7-81ac-020a5569db1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test27293wdqwdqw73937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c1077a7e-2d5a-4d6e-9a9f-f63a6c033ad5", "e9ed9e6e-9cf5-4697-a9be-449e949c0fb2" });

            migrationBuilder.CreateIndex(
                name: "IX_rentals_EmployeeId",
                table: "rentals",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_Employees_EmployeeId",
                table: "rentals",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_Employees_EmployeeId",
                table: "rentals");

            migrationBuilder.DropIndex(
                name: "IX_rentals_EmployeeId",
                table: "rentals");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "rentals");

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
    }
}
