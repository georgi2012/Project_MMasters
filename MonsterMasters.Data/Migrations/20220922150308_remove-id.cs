using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterMasters.Data.Migrations
{
    public partial class removeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "11fd348f-6bc8-4e0f-88fe-0a8e5405490d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3caa78f7-b2ac-427e-8bdb-4a768424cecd");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Creatures");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "58dd5c55-97ae-47b2-a9cc-4180ac5d9a95", "5a6ae9da-9d94-40c7-8ecb-9505cfb2f156", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9df11bea-f8b6-4941-a51a-40e14c90303b", "25e2994a-cdcd-46e7-b7ef-40ff4e0aae17", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58dd5c55-97ae-47b2-a9cc-4180ac5d9a95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9df11bea-f8b6-4941-a51a-40e14c90303b");

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "Creatures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "11fd348f-6bc8-4e0f-88fe-0a8e5405490d", "97c6a150-44f9-4cfa-ba4a-52548b288de0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3caa78f7-b2ac-427e-8bdb-4a768424cecd", "73a4baff-155c-4d5c-a80a-e79e01e03dbb", "Customer", "CUSTOMER" });
        }
    }
}
