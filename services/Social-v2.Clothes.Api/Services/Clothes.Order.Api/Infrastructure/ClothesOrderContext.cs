using Clothes.Order.Api.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clothes.Order.Api.Infrastructure
{
    public class ClothesOrderContext : DbContext
    {

        public ClothesOrderContext(DbContextOptions<ClothesOrderContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(x => x.Id);

                entity.OwnsOne(x => x.Customer);
                entity.OwnsOne(x => x.ShippingAddress);
            });

            modelBuilder.Entity<OrderDetailEntity>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(x => x.Id);
                entity
                    .HasOne(x => x.Order)
                    .WithMany(order => order.OrderDetails)
                    .HasForeignKey(x => x.OrderId);

                entity.OwnsOne(x => x.Product);
            });
        }
    }
}
