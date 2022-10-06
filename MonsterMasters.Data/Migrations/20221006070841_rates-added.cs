using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterMasters.Data.Migrations
{
    public partial class ratesadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f5706e0-97bb-4df8-8e12-5d3ef706d599");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "920f9471-7a31-4e9e-8c01-d65e83ffad5f");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Orb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Orb",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Index = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrbIndex = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Index);
                    table.ForeignKey(
                        name: "FK_Rates_Orb_OrbIndex",
                        column: x => x.OrbIndex,
                        principalTable: "Orb",
                        principalColumn: "Index",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "428cff6e-a9cc-445d-998c-53088e65607b", "ecf5a76a-0e5c-4214-8638-b1f94db54436", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ca06a6d-8e8d-45ef-b56c-a38c5e2e61e5", "759ca4ab-d28b-4330-96d3-8cd8eae2bdd5", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Rates_OrbIndex",
                table: "Rates",
                column: "OrbIndex");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "428cff6e-a9cc-445d-998c-53088e65607b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ca06a6d-8e8d-45ef-b56c-a38c5e2e61e5");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Orb");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f5706e0-97bb-4df8-8e12-5d3ef706d599", "e85abd41-dfc8-4a4c-b00c-1dc5c92e7bca", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "920f9471-7a31-4e9e-8c01-d65e83ffad5f", "d528e18c-e237-4fb8-ae90-9aa9899a32d1", "Admin", "ADMIN" });
        }
    }
}
