using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public static class ConfigureEntity
    {
        public static void AddProductTypeEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductEntity>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(x => x.Id);

                entity
                    .HasOne(x => x.Collection)
                    .WithMany(collection => collection.Products)
                    .HasForeignKey(x => x.CollectionId);
            });

            modelBuilder.Entity<ProductOptionEntity>(entity =>
            {
                entity.ToTable("ProductOption");
                entity.HasKey(x => x.Id);

                entity
                    .HasOne(x => x.Product)
                    .WithMany(proOption => proOption.Options)
                    .HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<ProductOptionValueEntity>(entity =>
            {
                entity.ToTable("ProductOptionValue");
                entity.HasKey(x => x.Id);

                entity
                    .HasOne(x => x.Option)
                    .WithMany(proOptionValue => proOptionValue.OptionValues)
                    .HasForeignKey(x => x.OptionId);
            });

            modelBuilder.Entity<ProductVarientEntity>(entity =>
            {
                entity.ToTable("ProductVarient");
                entity.HasKey(x => x.Id);

                entity
                    .HasOne(x => x.Product)
                    .WithMany(proOptionValue => proOptionValue.ProductVarients)
                    .HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<ProductSkuMediaEntity>(entity =>
            {
                entity.ToTable("ProductVarientMedia");
                entity.HasKey(x => x.Id);

                entity
                  .HasOne(x => x.ProductVarient)
                  .WithMany(pro => pro.ProductMedias)
                  .HasForeignKey(x => x.ProductVarientId);
            });

            modelBuilder.Entity<VarientValueEntity>(entity =>
            {
                entity.ToTable("VarientValue");
                entity.HasKey(x => x.Id);

                entity
                    .HasOne(x => x.ProductVarient)
                    .WithMany(proVarient => proVarient.VarientValues)
                    .HasForeignKey(x => x.ProductVarientId);

                entity
                    .HasOne(x => x.Product)
                    .WithMany(pro => pro.VarientValues)
                    .HasForeignKey(x => x.ProductId);

                entity
                    .HasOne(x => x.ProductOption)
                    .WithMany(opt => opt.VarientValues)
                    .HasForeignKey(x => x.ProductOptionId);

                entity
                    .HasOne(x => x.ProductOptionValue)
                    .WithMany(optValue => optValue.VarientValues)
                    .HasForeignKey(x => x.ProductOptionValueId);
            });
        }
    }
}
