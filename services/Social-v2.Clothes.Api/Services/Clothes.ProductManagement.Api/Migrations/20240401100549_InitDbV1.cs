using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clothes.ProductManagement.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitDbV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryEntity_Category_CategoryId",
                table: "ProductCategoryEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategoryEntity_ProductEntity_ProductId",
                table: "ProductCategoryEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_Collection_CollectionId",
                table: "ProductEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEntity_ProductType_ProductTypeId",
                table: "ProductEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTagEntity_ProductEntity_ProductId",
                table: "ProductTagEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTagEntity_Tag_TagId",
                table: "ProductTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTagEntity",
                table: "ProductTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductEntity",
                table: "ProductEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategoryEntity",
                table: "ProductCategoryEntity");

            migrationBuilder.RenameTable(
                name: "ProductTagEntity",
                newName: "ProductTag");

            migrationBuilder.RenameTable(
                name: "ProductEntity",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "ProductCategoryEntity",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTagEntity_TagId",
                table: "ProductTag",
                newName: "IX_ProductTag_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTagEntity_ProductId",
                table: "ProductTag",
                newName: "IX_ProductTag_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductEntity_ProductTypeId",
                table: "Product",
                newName: "IX_Product_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductEntity_CollectionId",
                table: "Product",
                newName: "IX_Product_CollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoryEntity_ProductId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategoryEntity_CategoryId",
                table: "ProductCategory",
                newName: "IX_ProductCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Collection_CollectionId",
                table: "Product",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                table: "Product",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Category_CategoryId",
                table: "ProductCategory",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Product_ProductId",
                table: "ProductCategory",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Product_ProductId",
                table: "ProductTag",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTag_Tag_TagId",
                table: "ProductTag",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Collection_CollectionId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductType_ProductTypeId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Category_CategoryId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Product_ProductId",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Product_ProductId",
                table: "ProductTag");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTag_Tag_TagId",
                table: "ProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTag",
                table: "ProductTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "ProductTag",
                newName: "ProductTagEntity");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategoryEntity");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "ProductEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTag_TagId",
                table: "ProductTagEntity",
                newName: "IX_ProductTagEntity_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTag_ProductId",
                table: "ProductTagEntity",
                newName: "IX_ProductTagEntity_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_ProductId",
                table: "ProductCategoryEntity",
                newName: "IX_ProductCategoryEntity_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategoryEntity",
                newName: "IX_ProductCategoryEntity_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductTypeId",
                table: "ProductEntity",
                newName: "IX_ProductEntity_ProductTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CollectionId",
                table: "ProductEntity",
                newName: "IX_ProductEntity_CollectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTagEntity",
                table: "ProductTagEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategoryEntity",
                table: "ProductCategoryEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductEntity",
                table: "ProductEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryEntity_Category_CategoryId",
                table: "ProductCategoryEntity",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategoryEntity_ProductEntity_ProductId",
                table: "ProductCategoryEntity",
                column: "ProductId",
                principalTable: "ProductEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntity_Collection_CollectionId",
                table: "ProductEntity",
                column: "CollectionId",
                principalTable: "Collection",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEntity_ProductType_ProductTypeId",
                table: "ProductEntity",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTagEntity_ProductEntity_ProductId",
                table: "ProductTagEntity",
                column: "ProductId",
                principalTable: "ProductEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTagEntity_Tag_TagId",
                table: "ProductTagEntity",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
