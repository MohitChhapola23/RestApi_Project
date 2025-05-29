using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewRestApiProject.Migrations
{
    /// <inheritdoc />
    public partial class initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Employees",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "DateOfBrith",
                table: "Employees",
                newName: "DateOfBirth");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 10, ".Net" },
                    { 20, "HR" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "LastName", "PhotoPath", "Sex" },
                values: new object[,]
                {
                    { 1001, new DateTime(1985, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "rai.verma@sircltech.com", "Rai", "Singh", "/images/rai.jpg", 0 },
                    { 1002, new DateTime(1986, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, "naresh@sircltech.com", "Naresh", "Verma", "/images/naresh.jpg", 0 },
                    { 1003, new DateTime(1982, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "rvinod@sircltech.com", "Vinod", "Kumar", "/images/vinod.jpg", 0 },
                    { 1004, new DateTime(1988, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "rishi@sircltech.com", "Rishi", "Kumar", "/images/rishi.jpg", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 20);

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "Employees",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Employees",
                newName: "DateOfBrith");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
