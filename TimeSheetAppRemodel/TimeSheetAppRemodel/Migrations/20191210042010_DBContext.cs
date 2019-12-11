using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetAppRemodel.Migrations
{
    public partial class DBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users",
                schema: "TimeSheet",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "TimeSheet",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutLunch",
                schema: "TimeSheet",
                table: "TimeClock",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "InLunch",
                schema: "TimeSheet",
                table: "TimeClock",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClockOut",
                schema: "TimeSheet",
                table: "TimeClock",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClockIn",
                schema: "TimeSheet",
                table: "TimeClock",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                schema: "TimeSheet",
                table: "Payroll",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<DateTime>(
                name: "TotalHours",
                schema: "TimeSheet",
                table: "TimeClock",
                type: "datetime",
                nullable: false,
                computedColumnSql: "([ClockIn]+[ClockOut])-([InLunch]+[OutLunch])",
                oldClrType: typeof(DateTime));

            migrationBuilder.CreateIndex(
                name: "Users",
                schema: "TimeSheet",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Users",
                schema: "TimeSheet",
                table: "TimeClock",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Payroll",
                schema: "TimeSheet",
                table: "Payroll",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Divisions",
                schema: "TimeSheet",
                table: "Divisions",
                column: "ID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Users",
                schema: "TimeSheet",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "Users",
                schema: "TimeSheet",
                table: "TimeClock");

            migrationBuilder.DropIndex(
                name: "Payroll",
                schema: "TimeSheet",
                table: "Payroll");

            migrationBuilder.DropIndex(
                name: "Divisions",
                schema: "TimeSheet",
                table: "Divisions");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                schema: "TimeSheet",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TotalHours",
                schema: "TimeSheet",
                table: "TimeClock",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldComputedColumnSql: "([ClockIn]+[ClockOut])-([InLunch]+[OutLunch])");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OutLunch",
                schema: "TimeSheet",
                table: "TimeClock",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InLunch",
                schema: "TimeSheet",
                table: "TimeClock",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClockOut",
                schema: "TimeSheet",
                table: "TimeClock",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ClockIn",
                schema: "TimeSheet",
                table: "TimeClock",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salary",
                schema: "TimeSheet",
                table: "Payroll",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.CreateIndex(
                name: "IX_Users",
                schema: "TimeSheet",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }
    }
}
