using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothes.User.Api.Migrations
{
    /// <inheritdoc />
    public partial class userServiceV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "ShippingAddress");

            migrationBuilder.RenameColumn(
                name: "Region",
                table: "ShippingAddress",
                newName: "WardOrCommune");

            migrationBuilder.RenameColumn(
                name: "Province",
                table: "ShippingAddress",
                newName: "ProvinceOrCity");

            migrationBuilder.RenameColumn(
                name: "DefaultAddress",
                table: "ShippingAddress",
                newName: "IsDefaultAddress");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "ShippingAddress",
                newName: "District");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "ShippingAddress",
                type: "text",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WardOrCommune",
                table: "ShippingAddress",
                newName: "Region");

            migrationBuilder.RenameColumn(
                name: "ProvinceOrCity",
                table: "ShippingAddress",
                newName: "Province");

            migrationBuilder.RenameColumn(
                name: "IsDefaultAddress",
                table: "ShippingAddress",
                newName: "DefaultAddress");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "ShippingAddress",
                newName: "City");

            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "ShippingAddress",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "ShippingAddress",
                type: "text",
                nullable: true);
        }
    }
}
