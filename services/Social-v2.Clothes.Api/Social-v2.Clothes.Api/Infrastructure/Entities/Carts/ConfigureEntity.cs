using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Cart
{
    public static class ConfigureEntity
    {
        public static void AddCartEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartEntity>(entity =>
            {
                entity.ToTable("Cart");
                entity.HasKey(x => x.Id);
                entity
                    .HasOne(cart => cart.Customer)
                    .WithOne(customer => customer.Cart)
                    .HasForeignKey<CartEntity>(x => x.CustomerId);
            });

            modelBuilder.Entity<CartItemEntity>(entity =>
            {
                entity.ToTable("CartItem");
                entity.HasKey(x => x.Id);
                entity
                    .HasOne(x => x.Cart)
                    .WithMany(cart => cart.CartItems)
                    .HasForeignKey(x => x.CartId);

                entity
                    .HasOne(x => x.ProductVarient)
                    .WithOne(cartItem => cartItem.CartItem)
                    .HasForeignKey<CartItemEntity>(x => x.ProductVarientId);
            });
        }
    }
}
