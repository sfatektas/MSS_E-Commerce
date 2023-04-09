using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class sizeSeedDataConfigurationEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "IsActive", "SizeTypeId", "Value" },
                values: new object[,]
                {
                    { 1, true, 1, "Small" },
                    { 2, true, 1, "Medium" },
                    { 3, true, 1, "Large" },
                    { 4, true, 1, "XXL" },
                    { 5, true, 1, "XXXL" },
                    { 6, true, 2, "29 30" },
                    { 7, true, 2, "29 31" },
                    { 8, true, 2, "29 32" },
                    { 9, true, 2, "30 31" },
                    { 10, true, 2, "30 32" },
                    { 11, true, 3, "36" },
                    { 12, true, 3, "37" },
                    { 13, true, 3, "38" },
                    { 14, true, 3, "39" },
                    { 15, true, 3, "40" },
                    { 16, true, 3, "41" },
                    { 17, true, 3, "41.5" },
                    { 18, true, 3, "42" },
                    { 19, true, 3, "42.5" },
                    { 20, true, 3, "43" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Sizes",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
