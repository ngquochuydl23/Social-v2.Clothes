using Clothes.User.Api.Infrastucture.Entities.ShippingAddresses;
using Clothes.User.Api.Infrastucture.Entities.Wishlists;
using Microsoft.EntityFrameworkCore;

namespace Clothes.User.Api.Infrastucture
{
    public class ClothesUserContext: DbContext
    {
        public ClothesUserContext(DbContextOptions<ClothesUserContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddWishList();
            modelBuilder.AddShippingAddress();
        }
    }
}
