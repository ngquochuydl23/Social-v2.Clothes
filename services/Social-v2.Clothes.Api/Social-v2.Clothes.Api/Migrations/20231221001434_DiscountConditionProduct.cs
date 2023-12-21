using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class DiscountConditionProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_DiscountCondition_DiscountConditionEntityDiscountCo~",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_DiscountConditionEntityDiscountCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DiscountConditionEntityDiscountCode",
                table: "Product");

            migrationBuilder.CreateTable(
                name: "ProductDiscountCondition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DiscountConditionId = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDiscountCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDiscountCondition_DiscountCondition_DiscountConditio~",
                        column: x => x.DiscountConditionId,
                        principalTable: "DiscountCondition",
                        principalColumn: "DiscountCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDiscountCondition_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscountCondition_DiscountConditionId",
                table: "ProductDiscountCondition",
                column: "DiscountConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDiscountCondition_ProductId",
                table: "ProductDiscountCondition",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDiscountCondition");

            migrationBuilder.AddColumn<string>(
                name: "DiscountConditionEntityDiscountCode",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_DiscountConditionEntityDiscountCode",
                table: "Product",
                column: "DiscountConditionEntityDiscountCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_DiscountCondition_DiscountConditionEntityDiscountCo~",
                table: "Product",
                column: "DiscountConditionEntityDiscountCode",
                principalTable: "DiscountCondition",
                principalColumn: "DiscountCode");
        }
    }
}
