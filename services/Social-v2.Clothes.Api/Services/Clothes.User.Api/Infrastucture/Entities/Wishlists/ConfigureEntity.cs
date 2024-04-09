using Clothes.User.Api.Infrastucture.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace Clothes.User.Api.Infrastucture.Entities.Wishlists
{
    public static class ConfigureEntity
    {
        public static void AddWishList(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishlistEntity>()
                .ToTable("WishList")
                .HasKey(x => x.Id);

            modelBuilder.Entity<WishlistEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.Wishlists)
                .HasForeignKey(x => x.UserId);         
                
        }
    }
}
