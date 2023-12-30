using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Orders;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Orders
{
    public static class ConfigureEntity
    {
        public static void AddOrderTypeEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderEntity>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(x => x.Id);

                entity
                    .HasOne(x => x.Customer)
                    .WithOne(customer => customer.Order)
                    .HasForeignKey<OrderEntity>(x => x.CustomerId);

                entity
                    .HasOne(orderDetail => orderDetail.DeliveryAddress)
                    .WithOne(address => address.Order)
                    .HasForeignKey<OrderEntity>(x => x.DeliveryAddressId);
            });

            modelBuilder.Entity<OrderDetailEntity>(entity =>
            {
                entity.ToTable("OrderDetail");
                entity.HasKey(x => x.Id);

                entity
                    .HasOne(orderDetail => orderDetail.Order)
                    .WithMany(order => order.OrderDetails)
                    .HasForeignKey(orderDetail => orderDetail.OrderId);

                entity
                    .HasOne(orderDetail => orderDetail.ProductVarient)
                    .WithOne(proVarient => proVarient.OrderDetail)
                    .HasForeignKey<OrderDetailEntity>(x => x.ProductVarientId);
            });
        }
    }
}
