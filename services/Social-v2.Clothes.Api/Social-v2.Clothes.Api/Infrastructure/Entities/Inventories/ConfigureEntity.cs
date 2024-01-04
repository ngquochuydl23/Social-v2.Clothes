using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Inventories
{
    public static class ConfigureEntity
    {
        public static void AddInventoryEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryEntity>(entity =>
            {
                entity.ToTable("Inventory");
                entity.HasKey(x => x.ProductVarientId);
                entity
                    .HasOne(x => x.ProductVarient)
                    .WithOne(pro => pro.Inventory)
                    .HasForeignKey<InventoryEntity>(x => x.ProductVarientId);
            });
        }
    }
}
