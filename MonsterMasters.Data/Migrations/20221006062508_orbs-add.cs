using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterMasters.Data.Migrations
{
    public partial class orbsadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2554b813-5996-454f-82c2-02f1bb6db98b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7fc0519-ba4c-4ed1-878a-1d69e1d8e1c4");

            migrationBuilder.CreateTable(
                name: "Orb",
                columns: table => new
                {
                    Index = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orb", x => x.Index);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f5706e0-97bb-4df8-8e12-5d3ef706d599", "e85abd41-dfc8-4a4c-b00c-1dc5c92e7bca", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "920f9471-7a31-4e9e-8c01-d65e83ffad5f", "d528e18c-e237-4fb8-ae90-9aa9899a32d1", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f5706e0-97bb-4df8-8e12-5d3ef706d599");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "920f9471-7a31-4e9e-8c01-d65e83ffad5f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2554b813-5996-454f-82c2-02f1bb6db98b", "a8ad5d7d-3ddf-441a-a247-6e689bd56da8", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f7fc0519-ba4c-4ed1-878a-1d69e1d8e1c4", "12b49317-5a92-4f8e-8661-b82189e90567", "Admin", "ADMIN" });
        }
    }
}
