using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class SizeTypeseedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SizeTypes",
                columns: new[] { "Id", "Defination", "IsActive" },
                values: new object[,]
                {
                    { 1, "Small", true },
                    { 2, "Medium", true },
                    { 3, "Large", true },
                    { 4, "XLarge", true },
                    { 5, "XXLARGE", true }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
