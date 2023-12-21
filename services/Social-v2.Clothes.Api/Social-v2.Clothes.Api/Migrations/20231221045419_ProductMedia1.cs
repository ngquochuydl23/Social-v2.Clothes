using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class ProductMedia1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RootOptionValueId",
                table: "ProductVarientMediaSet",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_ProductVarientMediaSet_RootOptionValueId",
                table: "ProductVarientMediaSet",
                column: "RootOptionValueId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVarientMediaSet_ProductOptionValue_RootOptionValueId",
                table: "ProductVarientMediaSet",
                column: "RootOptionValueId",
                principalTable: "ProductOptionValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVarientMediaSet_ProductOptionValue_RootOptionValueId",
                table: "ProductVarientMediaSet");

            migrationBuilder.DropIndex(
                name: "IX_ProductVarientMediaSet_RootOptionValueId",
                table: "ProductVarientMediaSet");

            migrationBuilder.DropColumn(
                name: "RootOptionValueId",
                table: "ProductVarientMediaSet");
        }
    }
}
