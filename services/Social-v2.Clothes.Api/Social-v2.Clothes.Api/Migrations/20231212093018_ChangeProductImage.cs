using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMedia_Product_ProductId",
                table: "ProductMedia");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProductMedia",
                newName: "ProductSkuId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMedia_ProductId",
                table: "ProductMedia",
                newName: "IX_ProductMedia_ProductSkuId");

            migrationBuilder.AddColumn<string>(
                name: "StockLocationId",
                table: "InventoryEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMedia_ProductSku_ProductSkuId",
                table: "ProductMedia",
                column: "ProductSkuId",
                principalTable: "ProductSku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductMedia_ProductSku_ProductSkuId",
                table: "ProductMedia");

            migrationBuilder.DropColumn(
                name: "StockLocationId",
                table: "InventoryEntity");

            migrationBuilder.RenameColumn(
                name: "ProductSkuId",
                table: "ProductMedia",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMedia_ProductSkuId",
                table: "ProductMedia",
                newName: "IX_ProductMedia_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMedia_Product_ProductId",
                table: "ProductMedia",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
