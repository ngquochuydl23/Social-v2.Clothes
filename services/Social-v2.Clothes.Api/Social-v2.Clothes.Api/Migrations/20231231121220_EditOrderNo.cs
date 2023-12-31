using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Social_v2.Clothes.Api.Migrations
{
    /// <inheritdoc />
    public partial class EditOrderNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "OrderNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderNo",
                table: "Order",
                newName: "Id");
        }
    }
}
