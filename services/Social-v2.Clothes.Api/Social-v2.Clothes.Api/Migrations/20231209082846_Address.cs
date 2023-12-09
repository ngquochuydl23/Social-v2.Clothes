using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class Address : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeliveryAddress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    DetailAddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ProvinceOrCity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    District = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    WardOrCommune = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryAddress_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryAddress_UserId",
                table: "DeliveryAddress",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryAddress");
        }
    }
}
