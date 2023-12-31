using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class TagEntity: Entity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [NotNull]
        public string Id { get; set; }

        public string TagName { get; set; }

        public ICollection<ProductTagEntity> ProductTags { get; set; } = new List<ProductTagEntity>();

        public TagEntity(string tagName) {
            Id = GenerateStringId(tagName);
            TagName = tagName;
        }
    }
}
