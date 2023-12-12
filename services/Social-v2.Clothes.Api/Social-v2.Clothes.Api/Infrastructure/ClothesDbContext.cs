
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists;
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
                .WithMany(user => user.DeliveryAddresses)
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

      modelBuilder.Entity<ProductSkuEntity>(entity =>
      {
        entity.ToTable("ProductSku");
        entity.HasKey(x => x.Id);

        entity
                  .HasOne(x => x.Product)
                  .WithMany(proOptionValue => proOptionValue.ProductSkus)
                  .HasForeignKey(x => x.ProductId);
      });

      modelBuilder.Entity<SkuValueEntity>(entity =>
      {
        entity.ToTable("SkuValue");
        entity.HasKey(x => x.Id);

        entity
                  .HasOne(x => x.ProductSku)
                  .WithMany(proSku => proSku.SkuValues)
                  .HasForeignKey(x => x.ProductSkuId);


        entity
                  .HasOne(x => x.Product)
                  .WithMany(pro => pro.SkuValues)
                  .HasForeignKey(x => x.ProductId);


        entity
                  .HasOne(x => x.ProductOption)
                  .WithMany(opt => opt.SkuValues)
                  .HasForeignKey(x => x.ProductOptionId);

        entity
                  .HasOne(x => x.ProductOptionValue)
                  .WithMany(optValue => optValue.SkuValues)
                  .HasForeignKey(x => x.ProductOptionValueId);
      });

      modelBuilder.Entity<WishlistEntity>(entity =>
      {
        entity.ToTable("Wishlist");
        entity.HasKey(x => x.Id);

        entity
                  .HasOne(x => x.ProductSku)
                  .WithOne(proSku => proSku.Wishlist)
                  .HasForeignKey<WishlistEntity>(x => x.ProductSkuId);

        entity
                 .HasOne(x => x.Customer)
                 .WithMany(cus => cus.Wishlists)
                 .HasForeignKey(x => x.CustomerId);
      });


      modelBuilder.Entity<CategoryEntity>(entity =>
      {
        entity.ToTable("Category");
        entity.HasKey(x => x.Id);

        entity
                  .HasOne(child => child.ParentCategory)
                  .WithMany(parent => parent.ChildCategories)
                  .HasForeignKey(x => x.ParentCategoryId);


      });

      modelBuilder.Entity<CategoryProductEntity>(entity =>
      {
        entity.ToTable("CategoryProduct");
        entity.HasKey(table => new
        {
          table.ProductId,
          table.CategoryId
        });


        entity
                  .HasOne(x => x.Category)
                  .WithMany(cate => cate.CategoryProducts)
                  .HasForeignKey(x => x.CategoryId);

        entity
                  .HasOne(x => x.Product)
                  .WithMany(pro => pro.CategoryProducts)
                  .HasForeignKey(x => x.ProductId);
      });
    }
  }
}
