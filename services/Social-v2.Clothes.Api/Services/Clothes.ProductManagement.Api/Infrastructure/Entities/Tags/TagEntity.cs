using Clothes.Commons.Seedworks;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTags
{
    public class TagEntity : Entity<long>
    {
        public string Value { get; set; }


        public TagEntity() { }

        public TagEntity(string value)
        {
            Value = value;
        }
    }
}
