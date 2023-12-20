using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses
{
    public static class ConfigureEntity
    {
        public static void AddDeliveryAddressEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeliveryAddressEntity>(entity =>
            {
                entity.ToTable("DeliveryAddress");
                entity.HasKey(x => x.Id);
                entity
                  .HasOne(x => x.User)
                  .WithMany(user => user.DeliveryAddresses)
                  .HasForeignKey(x => x.UserId);
            });

        }
    }
}
