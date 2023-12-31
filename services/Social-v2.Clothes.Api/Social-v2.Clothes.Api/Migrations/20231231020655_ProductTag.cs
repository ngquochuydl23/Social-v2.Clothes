using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class ProductTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "OrderDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "TaxTotal",
                table: "OrderDetail",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Thumbnail",
                table: "OrderDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "OrderDetail",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTag",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    TagId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTag", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTag_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductTag_TagId",
                table: "ProductTag",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductTag");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "TaxTotal",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Thumbnail",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "OrderDetail");
        }
    }
}
