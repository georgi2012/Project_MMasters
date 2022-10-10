using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonsterMasters.Data.Migrations
{
    public partial class usermonetization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "428cff6e-a9cc-445d-998c-53088e65607b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ca06a6d-8e8d-45ef-b56c-a38c5e2e61e5");

            migrationBuilder.AddColumn<long>(
                name: "Money",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a20f68cd-053c-4c6f-9115-2466acb19773", "828d10dc-d56e-4696-96bb-d15315b3c95e", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b9cadc84-5e40-44d1-ae66-0ae08afb490d", "1a5654c2-d7f6-4df6-9d83-873b95bf1348", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a20f68cd-053c-4c6f-9115-2466acb19773");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9cadc84-5e40-44d1-ae66-0ae08afb490d");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "428cff6e-a9cc-445d-998c-53088e65607b", "ecf5a76a-0e5c-4214-8638-b1f94db54436", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4ca06a6d-8e8d-45ef-b56c-a38c5e2e61e5", "759ca4ab-d28b-4330-96d3-8cd8eae2bdd5", "Admin", "ADMIN" });
        }
    }
}
