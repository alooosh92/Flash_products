using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Flash_products.Migrations
{
    public partial class _20230426_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategorieId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "House_fields",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Car_Fields",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategorieId",
                table: "Products",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_House_fields_ProductId",
                table: "House_fields",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_Fields_ProductId",
                table: "Car_Fields",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Fields_Products_ProductId",
                table: "Car_Fields",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_House_fields_Products_ProductId",
                table: "House_fields",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategorieId",
                table: "Products",
                column: "CategorieId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Fields_Products_ProductId",
                table: "Car_Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_House_fields_Products_ProductId",
                table: "House_fields");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategorieId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategorieId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_House_fields_ProductId",
                table: "House_fields");

            migrationBuilder.DropIndex(
                name: "IX_Car_Fields_ProductId",
                table: "Car_Fields");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "House_fields");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Car_Fields");
        }
    }
}
