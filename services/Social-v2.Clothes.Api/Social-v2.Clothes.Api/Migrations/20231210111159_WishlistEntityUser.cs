using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class WishlistEntityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CustomerId",
                table: "Wishlist",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_CustomerId",
                table: "Wishlist",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_User_CustomerId",
                table: "Wishlist",
                column: "CustomerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_User_CustomerId",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_CustomerId",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Wishlist");
        }
    }
}
