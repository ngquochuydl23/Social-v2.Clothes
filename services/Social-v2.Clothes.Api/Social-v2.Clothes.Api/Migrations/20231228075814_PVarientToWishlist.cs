using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class PVarientToWishlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_ProductVarient_ProductSkuId",
                table: "Wishlist");

            migrationBuilder.RenameColumn(
                name: "ProductSkuId",
                table: "Wishlist",
                newName: "ProductVarientId");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlist_ProductSkuId",
                table: "Wishlist",
                newName: "IX_Wishlist_ProductVarientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_ProductVarient_ProductVarientId",
                table: "Wishlist",
                column: "ProductVarientId",
                principalTable: "ProductVarient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_ProductVarient_ProductVarientId",
                table: "Wishlist");

            migrationBuilder.RenameColumn(
                name: "ProductVarientId",
                table: "Wishlist",
                newName: "ProductSkuId");

            migrationBuilder.RenameIndex(
                name: "IX_Wishlist_ProductVarientId",
                table: "Wishlist",
                newName: "IX_Wishlist_ProductSkuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_ProductVarient_ProductSkuId",
                table: "Wishlist",
                column: "ProductSkuId",
                principalTable: "ProductVarient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
