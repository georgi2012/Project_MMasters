using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterMasters.Data.Migrations
{
    public partial class idfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5505a1d3-57b3-4514-aaa3-3906165652b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e854b8a-89d3-448d-a086-467508c4b0cc");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "Creatures",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11fd348f-6bc8-4e0f-88fe-0a8e5405490d", "97c6a150-44f9-4cfa-ba4a-52548b288de0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3caa78f7-b2ac-427e-8bdb-4a768424cecd", "73a4baff-155c-4d5c-a80a-e79e01e03dbb", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11fd348f-6bc8-4e0f-88fe-0a8e5405490d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3caa78f7-b2ac-427e-8bdb-4a768424cecd");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "Creatures",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5505a1d3-57b3-4514-aaa3-3906165652b4", "69627a50-5bc0-41c7-81b4-ffc9ff97445b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e854b8a-89d3-448d-a086-467508c4b0cc", "c8606def-e4e1-4c6f-8b95-49eca35924ad", "Customer", "CUSTOMER" });
        }
    }
}
