using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class Skus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductSku",
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
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkuValue");

            migrationBuilder.DropTable(
                name: "ProductSku");
        }
    }
}
