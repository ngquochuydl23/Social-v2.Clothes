using Clothes.Commons.Seedworks;
using Clothes.ProductManagement.Api.Infrastructure.Entities.Products;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.Collections
{
    public class CollectionEntity: Entity
    {
        public string Id { get; set; }

        public string Title {  get; set; }

        public string Handle {  get; set; }


        public ICollection<ProductEntity> Products = new List<ProductEntity>();

        public CollectionEntity(string title)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Handle = GenerateHandleByTitle(title);
        }
    }
}
