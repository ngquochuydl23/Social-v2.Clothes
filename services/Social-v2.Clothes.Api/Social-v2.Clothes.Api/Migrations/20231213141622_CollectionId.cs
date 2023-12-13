using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class CollectionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryEntity_ProductSku_ProductSkuId",
                table: "InventoryEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryEntity",
                table: "InventoryEntity");

            migrationBuilder.RenameTable(
                name: "InventoryEntity",
                newName: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "CollectionId",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "ProductSkuId");

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Handle = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CollectionId",
                table: "Product",
                column: "CollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductSku_ProductSkuId",
                table: "Inventory",
                column: "ProductSkuId",
                principalTable: "ProductSku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Collection_CollectionId",
                table: "Product",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductSku_ProductSkuId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Collection_CollectionId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_Product_CollectionId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "CollectionId",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "InventoryEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryEntity",
                table: "InventoryEntity",
                column: "ProductSkuId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryEntity_ProductSku_ProductSkuId",
                table: "InventoryEntity",
                column: "ProductSkuId",
                principalTable: "ProductSku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
