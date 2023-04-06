using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class sizetypesEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Defination",
                value: "Üst Giyim");

            migrationBuilder.UpdateData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Defination",
                value: "Alt Giyim");

            migrationBuilder.UpdateData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Defination",
                value: "Ayak Numarası");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Defination",
                value: "Small");

            migrationBuilder.UpdateData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Defination",
                value: "Medium");

            migrationBuilder.UpdateData(
                table: "SizeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "Defination",
                value: "Large");

            migrationBuilder.InsertData(
                table: "SizeTypes",
                columns: new[] { "Id", "Defination", "IsActive" },
                values: new object[,]
                {
                    { 4, "XLarge", true },
                    { 5, "XXLARGE", true }
                });
        }
    }
}
