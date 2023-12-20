using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations
{
    public static class ConfigureEntity
    {
        public static void AddStockLocationEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventoryEntity>(entity =>
            {
                entity.ToTable("Inventory");
                entity.HasKey(x => x.ProductSkuId);
                entity
                    .HasOne(x => x.ProductSku)
                    .WithOne(pro => pro.Inventory)
                    .HasForeignKey<InventoryEntity>(x => x.ProductSkuId);
            });


            modelBuilder.Entity<StockLocationInventoryEntity>(entity =>
            {
                entity.ToTable("StockLocationInventory");
                entity.HasKey(table => new
                {
                    table.ProductSkuId,
                    table.StockLocationId
                });

                entity
                    .HasOne(x => x.Inventory)
                    .WithMany(inventory => inventory.StockLocationInventories)
                    .HasForeignKey(x => x.ProductSkuId);

                entity
                    .HasOne(x => x.StockLocation)
                    .WithMany(stock => stock.StockLocationInventories)
                    .HasForeignKey(x => x.ProductSkuId);
            });
        }
    }
}
