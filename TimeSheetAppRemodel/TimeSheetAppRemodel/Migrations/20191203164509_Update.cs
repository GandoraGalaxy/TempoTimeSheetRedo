using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetAppRemodel.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Divisions",
                schema: "TimeSheetApp",
                newName: "Divisions",
                newSchema: "TimeSheet");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Roles",
                newSchema: "TimeSheet");

            migrationBuilder.RenameTable(
                name: "Payroll",
                newName: "Payroll",
                newSchema: "TimeSheet");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "TimeSheet",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users",
                schema: "TimeSheet",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users",
                schema: "TimeSheet",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "TimeSheetApp");

            migrationBuilder.RenameTable(
                name: "Roles",
                schema: "TimeSheet",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Payroll",
                schema: "TimeSheet",
                newName: "Payroll");

            migrationBuilder.RenameTable(
                name: "Divisions",
                schema: "TimeSheet",
                newName: "Divisions",
                newSchema: "TimeSheetApp");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "TimeSheet",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
