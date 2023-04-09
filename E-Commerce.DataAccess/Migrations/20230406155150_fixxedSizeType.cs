using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.DataAccess.Migrations
{
    public partial class fixxedSizeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_SizeTypes_SizeTypeId1",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SizeTypeId1",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "SizeTypeId1",
                table: "Sizes");

            migrationBuilder.AlterColumn<int>(
                name: "SizeTypeId",
                table: "Sizes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeTypeId",
                table: "Sizes",
                column: "SizeTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_SizeTypes_SizeTypeId",
                table: "Sizes",
                column: "SizeTypeId",
                principalTable: "SizeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sizes_SizeTypes_SizeTypeId",
                table: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_Sizes_SizeTypeId",
                table: "Sizes");

            migrationBuilder.AlterColumn<string>(
                name: "SizeTypeId",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SizeTypeId1",
                table: "Sizes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_SizeTypeId1",
                table: "Sizes",
                column: "SizeTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Sizes_SizeTypes_SizeTypeId1",
                table: "Sizes",
                column: "SizeTypeId1",
                principalTable: "SizeTypes",
                principalColumn: "Id");
        }
    }
}
