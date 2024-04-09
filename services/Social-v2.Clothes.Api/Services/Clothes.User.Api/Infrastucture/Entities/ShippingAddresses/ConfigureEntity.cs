using Microsoft.EntityFrameworkCore;

namespace Clothes.User.Api.Infrastucture.Entities.ShippingAddresses
{
    public static class ConfigureEntity
    {
        public static void AddShippingAddress(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShippingAddressEntity>()
                .ToTable("ShippingAddress")
                .HasKey(x => x.Id);

            modelBuilder.Entity<ShippingAddressEntity>()
                .HasOne(x => x.User)
                .WithMany(x => x.ShippingAddresses)
                .HasForeignKey(x => x.UserId);
        }
    }
}
