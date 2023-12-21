using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class DiscountEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiscountConditionEntityDiscountCode",
                table: "Product",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    StartsAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndsAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsDisabled = table.Column<bool>(type: "boolean", nullable: false),
                    UsageLimit = table.Column<int>(type: "integer", nullable: false),
                    RuleType = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    RuleAllocation = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    RuleValue = table.Column<int>(type: "integer", nullable: false),
                    RuleDescription = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DiscountCondition",
                columns: table => new
                {
                    DiscountCode = table.Column<string>(type: "text", nullable: false),
                    Operator = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountCondition", x => x.DiscountCode);
                    table.ForeignKey(
                        name: "FK_DiscountCondition_Discount_DiscountCode",
                        column: x => x.DiscountCode,
                        principalTable: "Discount",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_DiscountCondition_DiscountConditionEntityDiscountCo~",
                table: "Product");

            migrationBuilder.DropTable(
                name: "DiscountCondition");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropIndex(
                name: "IX_Product_DiscountConditionEntityDiscountCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DiscountConditionEntityDiscountCode",
                table: "Product");
        }
    }
}
