using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductTagEntity: Entity
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [NotNull]
        public string Id { get; set; }

        public string TagName { get; set; }


        public ProductTagEntity(string tagName) {
            Id = GenerateStringId(TagName);
            TagName = tagName;
        }

    }
}
