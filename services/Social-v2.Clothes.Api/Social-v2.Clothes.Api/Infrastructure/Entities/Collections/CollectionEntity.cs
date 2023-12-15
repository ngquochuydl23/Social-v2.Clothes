using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Collections
{
    public class CollectionEntity : Entity
    {
        [NotNull]
        public string Id { get; set; }

        [NotNull]
        [MaxLength(CollectionConstants.NameMaxLength)]
        public string Title
        {
            get { return Title; }
            set
            {
                Id = GenerateStringId(value);
                Title = value;
            }
        }

        [NotNull]
        public string Handle { get; set; }

        public ICollection<ProductEntity> Products { get; set; } = new List<ProductEntity>();

        public CollectionEntity(string title, string handle)
        {
            Id = GenerateStringId(title);
            Title = title;
            Handle = handle;
        }


    }
}
