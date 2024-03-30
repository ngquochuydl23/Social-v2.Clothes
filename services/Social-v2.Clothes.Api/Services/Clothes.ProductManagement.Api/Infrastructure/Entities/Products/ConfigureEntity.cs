using Microsoft.EntityFrameworkCore;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.Products
{
    public static class ConfigureEntity
    {
        public static void AddProductEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(x => x.Id);
                entity
                    .HasOne(x => x.ProductType)
                    .WithMany(productType => productType.Products)
                    .HasForeignKey(x => x.ProductTypeId);

                entity
                    .HasOne(x => x.Collection)
                    .WithMany(collection => collection.Products)
                    .HasForeignKey(x => x.CollectionId);

            });

            modelBuilder.Entity<ProductCategoryEntity>(entity =>
            {
                entity.ToTable("ProductCategory");
                entity.HasKey(x => x.Id);
                entity
                    .HasOne(x => x.Product)
                    .WithMany(product => product.ProductCategories)
                    .HasForeignKey(x => x.ProductId);

                entity
                    .HasOne(x => x.Category)
                    .WithMany(category => category.ProductCategories)
                    .HasForeignKey(x => x.CategoryId);
            });
        }
    }
}
