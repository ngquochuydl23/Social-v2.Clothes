using Clothes.ProductManagement.Api.Infrastructure.Entities.Categories;
using Clothes.ProductManagement.Api.Infrastructure.Entities.Collections;
using Clothes.ProductManagement.Api.Infrastructure.Entities.Products;
using Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTypes;
using Clothes.ProductManagement.Api.Infrastructure.Entities.Tags;
using Microsoft.EntityFrameworkCore;

namespace Clothes.ProductManagement.Api.Infrastructure
{
    public class ClothesProductContext : DbContext
    {
        public ClothesProductContext(DbContextOptions<ClothesProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddCategories();
            modelBuilder.AddCollections();
            modelBuilder.AddProducts();
            modelBuilder.AddProductTypes();
            modelBuilder.AddTags();
        }
    }
}
