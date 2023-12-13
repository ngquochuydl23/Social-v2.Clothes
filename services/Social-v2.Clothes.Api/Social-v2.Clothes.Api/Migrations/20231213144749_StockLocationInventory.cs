using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class StockLocationInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StockLocationEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    DetailAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ProvinceOrCity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WardOrCommune = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLocationEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockLocationInventory",
                columns: table => new
                {
                    StockLocationId = table.Column<string>(type: "text", nullable: false),
                    ProductSkuId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLocationInventory", x => new { x.ProductSkuId, x.StockLocationId });
                    table.ForeignKey(
                        name: "FK_StockLocationInventory_Inventory_ProductSkuId",
                        column: x => x.ProductSkuId,
                        principalTable: "Inventory",
                        principalColumn: "ProductSkuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockLocationInventory_StockLocationEntity_ProductSkuId",
                        column: x => x.ProductSkuId,
                        principalTable: "StockLocationEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockLocationInventory");

            migrationBuilder.DropTable(
                name: "StockLocationEntity");
        }
    }
}
