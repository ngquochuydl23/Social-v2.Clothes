using Clothes.Commons.Seedworks;
using Clothes.ProductManagement.Api.Infrastructure.Entities.Categories;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.Products
{
    public class ProductCategoryEntity: Entity<long>
    {
        public string ProductId { get; set; }

        public string CategoryId { get; set; }

        public virtual ProductEntity Product { get; set; }

        public virtual CategoryEntity Category { get; set; }

        public ProductCategoryEntity(string productId, string categoryId) 
        {
            ProductId = productId;
            CategoryId = categoryId;
        }
    }
}
