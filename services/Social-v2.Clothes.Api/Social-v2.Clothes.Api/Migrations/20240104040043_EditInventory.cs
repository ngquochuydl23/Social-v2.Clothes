using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class EditInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductVarient_ProductSkuId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "StockLocationInventory");

            migrationBuilder.DropTable(
                name: "StockLocationEntity");

            migrationBuilder.DropColumn(
                name: "AllowBackOrder",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Ean",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "StockLocationId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Upc",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "ProductSkuId",
                table: "Inventory",
                newName: "ProductVarientId");

            migrationBuilder.AddColumn<long>(
                name: "ReservedQuantity",
                table: "Inventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "StockedQuantity",
                table: "Inventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductVarient_ProductVarientId",
                table: "Inventory",
                column: "ProductVarientId",
                principalTable: "ProductVarient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductVarient_ProductVarientId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "ReservedQuantity",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "StockedQuantity",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "ProductVarientId",
                table: "Inventory",
                newName: "ProductSkuId");

            migrationBuilder.AddColumn<bool>(
                name: "AllowBackOrder",
                table: "Inventory",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Ean",
                table: "Inventory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Inventory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StockLocationId",
                table: "Inventory",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Upc",
                table: "Inventory",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StockLocationEntity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DetailAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    District = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    ProvinceOrCity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WardOrCommune = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockLocationEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockLocationInventory",
                columns: table => new
                {
                    ProductSkuId = table.Column<string>(type: "text", nullable: false),
                    StockLocationId = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
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

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductVarient_ProductSkuId",
                table: "Inventory",
                column: "ProductSkuId",
                principalTable: "ProductVarient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
