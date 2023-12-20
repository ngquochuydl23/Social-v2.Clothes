using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Categories
{
    public static class ConfigureEntity
    {
        public static void AddCategoryEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(x => x.Id);
                entity
                    .HasOne(child => child.ParentCategory)
                    .WithMany(parent => parent.ChildCategories)
                    .HasForeignKey(x => x.ParentCategoryId);

                entity
                   .HasOne(x => x.ProductType)
                   .WithMany(proType => proType.Categories)
                   .HasForeignKey(x => x.ProductTypeId);
            });

            modelBuilder.Entity<CategoryProductEntity>(entity =>
            {
                entity.ToTable("CategoryProduct");
                entity.HasKey(table => new
                {
                    table.ProductId,
                    table.CategoryId
                });

                entity
                    .HasOne(x => x.Category)
                    .WithMany(cate => cate.CategoryProducts)
                    .HasForeignKey(x => x.CategoryId);

                entity
                    .HasOne(x => x.Product)
                    .WithMany(pro => pro.CategoryProducts)
                    .HasForeignKey(x => x.ProductId);
            });
        }
    }
}
