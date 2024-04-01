using Microsoft.EntityFrameworkCore;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.Categories
{
    public static class ConfigureEntity
    {
        public static void AddCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(x => x.Id);
 
            });
        }
    }
}
