using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class ProductMedia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVarientMedia_ProductVarient_ProductVarientId",
                table: "ProductVarientMedia");

            migrationBuilder.DropIndex(
                name: "IX_ProductVarientMedia_ProductVarientId",
                table: "ProductVarientMedia");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "ProductVarientMedia");

            migrationBuilder.DropColumn(
                name: "ProductVarientId",
                table: "ProductVarientMedia");

            migrationBuilder.RenameColumn(
                name: "Width",
                table: "ProductVarientMedia",
                newName: "MediaSetId");

            migrationBuilder.AddColumn<long>(
                name: "MediaSetId",
                table: "ProductVarient",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsRoot",
                table: "ProductOption",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ProductVarientMediaSet",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RootProductOptionId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVarientMediaSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductVarientMediaSet_ProductOption_RootProductOptionId",
                        column: x => x.RootProductOptionId,
                        principalTable: "ProductOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductVarientMedia_MediaSetId",
                table: "ProductVarientMedia",
                column: "MediaSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVarient_MediaSetId",
                table: "ProductVarient",
                column: "MediaSetId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVarientMediaSet_RootProductOptionId",
                table: "ProductVarientMediaSet",
                column: "RootProductOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVarient_ProductVarientMediaSet_MediaSetId",
                table: "ProductVarient",
                column: "MediaSetId",
                principalTable: "ProductVarientMediaSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVarientMedia_ProductVarientMediaSet_MediaSetId",
                table: "ProductVarientMedia",
                column: "MediaSetId",
                principalTable: "ProductVarientMediaSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVarient_ProductVarientMediaSet_MediaSetId",
                table: "ProductVarient");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVarientMedia_ProductVarientMediaSet_MediaSetId",
                table: "ProductVarientMedia");

            migrationBuilder.DropTable(
                name: "ProductVarientMediaSet");

            migrationBuilder.DropIndex(
                name: "IX_ProductVarientMedia_MediaSetId",
                table: "ProductVarientMedia");

            migrationBuilder.DropIndex(
                name: "IX_ProductVarient_MediaSetId",
                table: "ProductVarient");

            migrationBuilder.DropColumn(
                name: "MediaSetId",
                table: "ProductVarient");

            migrationBuilder.DropColumn(
                name: "IsRoot",
                table: "ProductOption");

            migrationBuilder.RenameColumn(
                name: "MediaSetId",
                table: "ProductVarientMedia",
                newName: "Width");

            migrationBuilder.AddColumn<long>(
                name: "Height",
                table: "ProductVarientMedia",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ProductVarientId",
                table: "ProductVarientMedia",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductVarientMedia_ProductVarientId",
                table: "ProductVarientMedia",
                column: "ProductVarientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVarientMedia_ProductVarient_ProductVarientId",
                table: "ProductVarientMedia",
                column: "ProductVarientId",
                principalTable: "ProductVarient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
