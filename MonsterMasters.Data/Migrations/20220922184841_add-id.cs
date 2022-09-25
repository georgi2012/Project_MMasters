using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterMasters.Data.Migrations
{
    public partial class addid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "2554b813-5996-454f-82c2-02f1bb6db98b", "a8ad5d7d-3ddf-441a-a247-6e689bd56da8", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7fc0519-ba4c-4ed1-878a-1d69e1d8e1c4", "12b49317-5a92-4f8e-8661-b82189e90567", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2554b813-5996-454f-82c2-02f1bb6db98b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7fc0519-ba4c-4ed1-878a-1d69e1d8e1c4");

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
    }
}
