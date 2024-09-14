using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Engineering", "Engineering" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Finance", "Finance" });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "Marketing", "Marketing" });

            migrationBuilder.InsertData(
                table: "Function",
                columns: new[] { "Id", "DepartmentId", "Description", "Name" },
                values: new object[] { 1, 1, "Associate Software Engineer", "Associate Software Engineer" });

            migrationBuilder.InsertData(
                table: "Function",
                columns: new[] { "Id", "DepartmentId", "Description", "Name" },
                values: new object[] { 2, 1, "Associate Software Engineer", "Software Engineer" });

            migrationBuilder.InsertData(
                table: "Function",
                columns: new[] { "Id", "DepartmentId", "Description", "Name" },
                values: new object[] { 3, 1, "Associate Software Engineer", "Senior Software Engineer" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FunctionId", "Name" },
                values: new object[] { 1, 1, "Taj" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FunctionId", "Name" },
                values: new object[] { 2, 1, "Rajneesh Kumar" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "FunctionId", "Name" },
                values: new object[] { 3, 1, "Sudhanshu Jain" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Function",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Function",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Function",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Department",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
