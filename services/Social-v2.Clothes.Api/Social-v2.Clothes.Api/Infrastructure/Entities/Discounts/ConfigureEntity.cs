using Microsoft.EntityFrameworkCore;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Discounts
{
    public static class ConfigureEntity
    {
        public static void AddDiscountEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DiscountEntity>(entity =>
            {
                entity.ToTable("Discount");
                entity.HasKey(x => x.Code);
            });

            modelBuilder.Entity<DiscountConditionEntity>(entity =>
            {
                entity.ToTable("DiscountCondition");
                entity.HasKey(x => x.DiscountCode);
                entity
                    .HasOne(x => x.Discount)
                    .WithOne(discount => discount.Condition)
                    .HasForeignKey<DiscountConditionEntity>(x => x.DiscountCode);
            });


            modelBuilder.Entity<ProductDiscountConditionEntity>(entity =>
            {
                entity.ToTable("ProductDiscountCondition");
                entity.HasKey(x => x.Id);

                entity
                    .HasOne(x => x.Product)
                    .WithMany(product => product.DiscountCondtionProducts)
                    .HasForeignKey(x => x.ProductId);

                entity
                    .HasOne(x => x.DiscountCondition)
                    .WithMany(condition => condition.DiscountCondtionProducts)
                    .HasForeignKey(x => x.DiscountConditionId);
            });
        }
    }
}
