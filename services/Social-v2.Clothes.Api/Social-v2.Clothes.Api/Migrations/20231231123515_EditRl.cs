using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class EditRl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Order_CustomerId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId",
                unique: true);
        }
    }
}
