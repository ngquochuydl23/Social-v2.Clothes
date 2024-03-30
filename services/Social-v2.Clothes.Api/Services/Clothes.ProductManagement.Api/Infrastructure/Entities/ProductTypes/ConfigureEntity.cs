using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTypes
{
    public static class ConfigureEntity
    {
        public static void AddProductType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTypeEntity>(entity =>
            {
                entity.ToTable("ProductType");
                entity.HasKey(x => x.Id);
            });
        }
    }
}
