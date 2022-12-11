using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Data.Migrations
{
    public partial class fixedproductmodel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productCategories_categoryId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_categoryId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "products");

            migrationBuilder.CreateIndex(
                name: "IX_products_productCategoryId",
                table: "products",
                column: "productCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productCategories_productCategoryId",
                table: "products",
                column: "productCategoryId",
                principalTable: "productCategories",
                principalColumn: "categoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productCategories_productCategoryId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_productCategoryId",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_categoryId",
                table: "products",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productCategories_categoryId",
                table: "products",
                column: "categoryId",
                principalTable: "productCategories",
                principalColumn: "categoryId");
        }
    }
}
