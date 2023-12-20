using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists
{
    public static class ConfigureEntity
    {
        public static void AddWishlistEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishlistEntity>(entity =>
            {
                entity.ToTable("Wishlist");
                entity.HasKey(x => x.Id);
                entity
                    .HasOne(x => x.ProductSku)
                    .WithOne(proSku => proSku.Wishlist)
                    .HasForeignKey<WishlistEntity>(x => x.ProductSkuId);

                entity
                   .HasOne(x => x.Customer)
                   .WithMany(cus => cus.Wishlists)
                   .HasForeignKey(x => x.CustomerId);
            });

        }
    }
}
