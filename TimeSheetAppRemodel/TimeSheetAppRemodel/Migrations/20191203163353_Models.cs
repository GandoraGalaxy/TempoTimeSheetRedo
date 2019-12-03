using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetAppRemodel.Migrations
{
    public partial class Models : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TimeSheetApp");

            migrationBuilder.EnsureSchema(
                name: "TimeSheet");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "TimeSheet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payroll",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Salary = table.Column<decimal>(nullable: false),
                    EmployeeIDId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payroll", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payroll_Users_EmployeeIDId",
                        column: x => x.EmployeeIDId,
                        principalSchema: "TimeSheet",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TimeClock",
                schema: "TimeSheet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ClockIn = table.Column<DateTime>(nullable: false),
                    InLunch = table.Column<DateTime>(nullable: false),
                    OutLunch = table.Column<DateTime>(nullable: false),
                    ClockOut = table.Column<DateTime>(nullable: false),
                    TotalHours = table.Column<DateTime>(nullable: false),
                    EmployeeIDId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeClock", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TimeClock_Users_EmployeeIDId",
                        column: x => x.EmployeeIDId,
                        principalSchema: "TimeSheet",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                schema: "TimeSheetApp",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Divisions_Users_User",
                        column: x => x.User,
                        principalSchema: "TimeSheet",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payroll_EmployeeIDId",
                table: "Payroll",
                column: "EmployeeIDId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeClock_EmployeeIDId",
                schema: "TimeSheet",
                table: "TimeClock",
                column: "EmployeeIDId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_User",
                schema: "TimeSheetApp",
                table: "Divisions",
                column: "User",
                unique: true,
                filter: "[User] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payroll");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TimeClock",
                schema: "TimeSheet");

            migrationBuilder.DropTable(
                name: "Divisions",
                schema: "TimeSheetApp");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "TimeSheet");
        }
    }
}
