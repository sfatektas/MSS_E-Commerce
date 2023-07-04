using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class favoriteProductFixxed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropIndex(
            //    name: "IX_FavoriteProducts_ProductsInStockId",
            //    table: "FavoriteProducts");

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
                value: "68a4d663-d061-4122-bbd7-8a83bf6df5ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "850aad67-9a53-446f-a4cc-65e9514bd262");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "6f980881-8eff-4fd7-b50c-770d9639e06f");

            //migrationBuilder.CreateIndex(
            //    name: "IX_FavoriteProducts_ProductsInStockId",
            //    table: "FavoriteProducts",
            //    column: "ProductsInStockId");
        }
    }
}
