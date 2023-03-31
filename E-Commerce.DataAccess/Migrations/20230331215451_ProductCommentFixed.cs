using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class ProductCommentFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductComment_AspNetUsers_SupplierId",
                table: "ProductComment");

            migrationBuilder.DropIndex(
                name: "IX_SuppliersProducts_SupplierId",
                table: "SuppliersProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProductComment_SupplierId",
                table: "ProductComment");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ProductComment");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductsInStocks",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuppliersProducts_SupplierId_ProductId_SizeId_ColorId",
                table: "SuppliersProducts",
                columns: new[] { "SupplierId", "ProductId", "SizeId", "ColorId" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId_Name",
                table: "Products",
                columns: new[] { "BrandId", "Name" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SuppliersProducts_SupplierId_ProductId_SizeId_ColorId",
                table: "SuppliersProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_BrandId_Name",
                table: "Products");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ProductsInStocks",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "ProductComment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SuppliersProducts_SupplierId",
                table: "SuppliersProducts",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductComment_SupplierId",
                table: "ProductComment",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductComment_AspNetUsers_SupplierId",
                table: "ProductComment",
                column: "SupplierId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
