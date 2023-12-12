using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class InventoryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryEntity",
                columns: table => new
                {
                    ProductSkuId = table.Column<string>(type: "text", nullable: false),
                    Ean = table.Column<int>(type: "integer", nullable: false),
                    Upc = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    AllowBackOrder = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryEntity", x => x.ProductSkuId);
                    table.ForeignKey(
                        name: "FK_InventoryEntity_ProductSku_ProductSkuId",
                        column: x => x.ProductSkuId,
                        principalTable: "ProductSku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryEntity");
        }
    }
}
