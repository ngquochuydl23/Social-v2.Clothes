using Clothes.Commons.Seedworks;
using Clothes.ProductManagement.Api.Infrastructure.Entities.Products;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTags
{
    public class TagEntity : Entity<long>
    {
        public string Value { get; set; }

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new List<ProductTagEntity>();
        public TagEntity() { }

        public TagEntity(string value)
        {
            Value = value;
        }
    }
}
