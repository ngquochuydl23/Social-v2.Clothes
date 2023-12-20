using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.ProductTypes
{
    public static class ConfigureEntity
    {
        public static void AddProductEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTypeEntity>(entity =>
            {
                entity.ToTable("ProductType");
                entity.HasKey(x => x.Id);

            });
        }
    }
}
