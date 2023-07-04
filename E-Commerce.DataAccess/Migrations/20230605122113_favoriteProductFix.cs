using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class favoriteProductFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FavoriteProducts_ProductsInStockId_CustomerId",
                table: "FavoriteProducts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fad6c111-ff59-4e50-a4e8-93959cd221d4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f7cc6be7-1b0d-4889-81ca-d724e6606a5b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "1155f032-aa6b-49aa-a0b2-03e5bd78c47e");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProductsInStockId_CustomerId",
                table: "FavoriteProducts",
                columns: new[] { "ProductsInStockId", "CustomerId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FavoriteProducts_ProductsInStockId_CustomerId",
                table: "FavoriteProducts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "c38132ae-b5f6-4eb7-9d97-773280a1fe57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "2076d41b-b76a-406d-b959-7701e8686d6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7e674d3e-cef5-4c08-a4de-f041d7c73b10");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteProducts_ProductsInStockId_CustomerId",
                table: "FavoriteProducts",
                columns: new[] { "ProductsInStockId", "CustomerId" });
        }
    }
}
