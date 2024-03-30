using Clothes.Commons.Seedworks;
using Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTags;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.Products
{
    public class ProductTagEntity: Entity<long>
    {
        public string ProductId { get; set; }

        public long TagId { get; set; }

        public virtual ProductEntity Product { get; set; }

        public virtual TagEntity Tag { get; set; }


        public ProductTagEntity() { }

        public ProductTagEntity(string productId, long tagId) 
        {
            ProductId = productId;
            TagId = tagId;
        }
    }
}
