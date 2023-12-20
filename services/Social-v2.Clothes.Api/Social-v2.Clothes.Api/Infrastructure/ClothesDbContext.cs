
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Collections;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Invites;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.ProductTypes;
using Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists;
using System.Reflection.Emit;

namespace Social_v2.Clothes.Api.Infrastructure
{
    public class ClothesDbContext : DbContext
    {
        public ClothesDbContext(DbContextOptions<ClothesDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddUserEntities();
            modelBuilder.AddDeliveryAddressEntities();
            modelBuilder.AddProductEntities();
            modelBuilder.AddCategoryEntities();
            modelBuilder.AddInventoryEntities();
            modelBuilder.AddStockLocationEntities();
            modelBuilder.AddWishlistEntities();
            modelBuilder.AddCollectionEntities();
            modelBuilder.AddProductTypeEntities();
            modelBuilder.AddInviteEntities();
        }
    }
}
