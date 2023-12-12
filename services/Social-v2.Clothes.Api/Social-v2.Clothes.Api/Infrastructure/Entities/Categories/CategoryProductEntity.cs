using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Categories
{
    public class CategoryProductEntity : Entity
    {
        public string CategoryId { get; set; }

        public string ProductId { get; set; }

        public virtual CategoryEntity Category { get; set; }

        public virtual ProductEntity Product { get; set; }


        public CategoryProductEntity(string categoryId, string productId)
        {
            CategoryId = categoryId;
            ProductId = productId;
        }
    }
}
