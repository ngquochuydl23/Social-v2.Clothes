using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothes.Order.Api.Migrations
{
    /// <inheritdoc />
    public partial class ShippingAddressVO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer_CustomerName",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Customer_Email",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Customer_Id",
                table: "Order",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Customer_PhoneNumber",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_DetailAddress",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_District",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_Name",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_PhoneNumber",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_ProvinceOrCity",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_WardOrCommune",
                table: "Order",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer_CustomerName",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Customer_Email",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Customer_Id",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Customer_PhoneNumber",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_DetailAddress",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_District",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_Name",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_PhoneNumber",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_ProvinceOrCity",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ShippingAddress_WardOrCommune",
                table: "Order");
        }
    }
}
