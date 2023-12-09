
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
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
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<DeliveryAddressEntity>(entity =>
            {
                entity.ToTable("DeliveryAddress");
                entity.HasKey(x => x.Id);
                entity
                  .HasOne(x => x.User)
                  .WithMany(user => user.DeliverAddresses)
                  .HasForeignKey(x => x.UserId);
            });


            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(x => x.Id);
            });

            modelBuilder.Entity<ProductMediaEntity>(entity =>
            {
                entity.ToTable("ProductMedia");
                entity.HasKey(x => x.Id);

                entity
                  .HasOne(x => x.Product)
                  .WithMany(pro => pro.ProductMedias)
                  .HasForeignKey(x => x.ProductId);
            });
        }
    }
}
