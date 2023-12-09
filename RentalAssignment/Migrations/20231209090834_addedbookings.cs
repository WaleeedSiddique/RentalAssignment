using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalAssignment.Migrations
{
    public partial class addedbookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_Employees_EmployeeId",
                table: "rentals");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "rentals");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "rentals",
                newName: "employeeid");

            migrationBuilder.RenameIndex(
                name: "IX_rentals_EmployeeId",
                table: "rentals",
                newName: "IX_rentals_employeeid");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "Test27293wdqwdqw73937898-329332ndyvyuhvjjhf8e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2ae5e7d1-8079-48df-be33-584a539cb3f3", "d7ed2a7f-643c-4e84-94e2-8b6ee5407781" });

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_Employees_employeeid",
                table: "rentals",
                column: "employeeid",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_Employees_employeeid",
                table: "rentals");

            migrationBuilder.RenameColumn(
                name: "employeeid",
                table: "rentals",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_rentals_employeeid",
                table: "rentals",
                newName: "IX_rentals_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_Employees_EmployeeId",
                table: "rentals",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
