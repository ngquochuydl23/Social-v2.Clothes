using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTypes
{
    public static class ConfigureEntity
    {
        public static void AddProductTypes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTypeEntity>(entity =>
            {
                entity.ToTable("ProductType");
                entity.HasKey(x => x.Id);
            });
        }
    }
}
