using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSkuToVarient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductSku_ProductSkuId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductMedia_ProductSku_ProductSkuId",
                table: "ProductMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_ProductSku_ProductSkuId",
                table: "Wishlist");

            migrationBuilder.DropTable(
                name: "SkuValue");

            migrationBuilder.DropTable(
                name: "ProductSku");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductMedia",
                table: "ProductMedia");

            migrationBuilder.RenameTable(
                name: "ProductMedia",
                newName: "ProductVarientMedia");

            migrationBuilder.RenameColumn(
                name: "ProductSkuId",
                table: "ProductVarientMedia",
                newName: "ProductVarientId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductMedia_ProductSkuId",
                table: "ProductVarientMedia",
                newName: "IX_ProductVarientMedia_ProductVarientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVarientMedia",
                table: "ProductVarientMedia",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductVarient",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVarient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVarient_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VarientValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    ProductOptionId = table.Column<long>(type: "bigint", nullable: false),
                    ProductOptionValueId = table.Column<long>(type: "bigint", nullable: false),
                    ProductVarientId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarientValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VarientValue_ProductOptionValue_ProductOptionValueId",
                        column: x => x.ProductOptionValueId,
                        principalTable: "ProductOptionValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VarientValue_ProductOption_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VarientValue_ProductVarient_ProductVarientId",
                        column: x => x.ProductVarientId,
                        principalTable: "ProductVarient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VarientValue_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVarient_ProductId",
                table: "ProductVarient",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VarientValue_ProductId",
                table: "VarientValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VarientValue_ProductOptionId",
                table: "VarientValue",
                column: "ProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_VarientValue_ProductOptionValueId",
                table: "VarientValue",
                column: "ProductOptionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_VarientValue_ProductVarientId",
                table: "VarientValue",
                column: "ProductVarientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductVarient_ProductSkuId",
                table: "Inventory",
                column: "ProductSkuId",
                principalTable: "ProductVarient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVarientMedia_ProductVarient_ProductVarientId",
                table: "ProductVarientMedia",
                column: "ProductVarientId",
                principalTable: "ProductVarient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_ProductVarient_ProductSkuId",
                table: "Wishlist",
                column: "ProductSkuId",
                principalTable: "ProductVarient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_ProductVarient_ProductSkuId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVarientMedia_ProductVarient_ProductVarientId",
                table: "ProductVarientMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_ProductVarient_ProductSkuId",
                table: "Wishlist");

            migrationBuilder.DropTable(
                name: "VarientValue");

            migrationBuilder.DropTable(
                name: "ProductVarient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVarientMedia",
                table: "ProductVarientMedia");

            migrationBuilder.RenameTable(
                name: "ProductVarientMedia",
                newName: "ProductMedia");

            migrationBuilder.RenameColumn(
                name: "ProductVarientId",
                table: "ProductMedia",
                newName: "ProductSkuId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVarientMedia_ProductVarientId",
                table: "ProductMedia",
                newName: "IX_ProductMedia_ProductSkuId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductMedia",
                table: "ProductMedia",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProductSku",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSku_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkuValue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    ProductOptionId = table.Column<long>(type: "bigint", nullable: false),
                    ProductOptionValueId = table.Column<long>(type: "bigint", nullable: false),
                    ProductSkuId = table.Column<string>(type: "text", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkuValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkuValue_ProductOptionValue_ProductOptionValueId",
                        column: x => x.ProductOptionValueId,
                        principalTable: "ProductOptionValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkuValue_ProductOption_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkuValue_ProductSku_ProductSkuId",
                        column: x => x.ProductSkuId,
                        principalTable: "ProductSku",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkuValue_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductSku_ProductId",
                table: "ProductSku",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuValue_ProductId",
                table: "SkuValue",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuValue_ProductOptionId",
                table: "SkuValue",
                column: "ProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuValue_ProductOptionValueId",
                table: "SkuValue",
                column: "ProductOptionValueId");

            migrationBuilder.CreateIndex(
                name: "IX_SkuValue_ProductSkuId",
                table: "SkuValue",
                column: "ProductSkuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_ProductSku_ProductSkuId",
                table: "Inventory",
                column: "ProductSkuId",
                principalTable: "ProductSku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductMedia_ProductSku_ProductSkuId",
                table: "ProductMedia",
                column: "ProductSkuId",
                principalTable: "ProductSku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_ProductSku_ProductSkuId",
                table: "Wishlist",
                column: "ProductSkuId",
                principalTable: "ProductSku",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
