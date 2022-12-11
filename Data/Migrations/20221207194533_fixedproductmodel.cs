using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Data.Migrations
{
    public partial class fixedproductmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productCategories_ProductTypeId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "ProductTypeId",
                table: "products",
                newName: "categoryId");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductTypeId",
                table: "products",
                newName: "IX_products_categoryId");

            migrationBuilder.AlterColumn<string>(
                name: "productImage",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "productColor",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productCategories_categoryId",
                table: "products",
                column: "categoryId",
                principalTable: "productCategories",
                principalColumn: "categoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productCategories_categoryId",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "categoryId",
                table: "products",
                newName: "ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_products_categoryId",
                table: "products",
                newName: "IX_products_ProductTypeId");

            migrationBuilder.AlterColumn<string>(
                name: "productImage",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "productColor",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_products_productCategories_ProductTypeId",
                table: "products",
                column: "ProductTypeId",
                principalTable: "productCategories",
                principalColumn: "categoryId");
        }
    }
}
