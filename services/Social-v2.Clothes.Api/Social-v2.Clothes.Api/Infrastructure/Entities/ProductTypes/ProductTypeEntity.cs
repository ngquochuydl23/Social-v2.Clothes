using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductTypeEntity : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [NotNull]
        public string Id { get; set; }

        public string Name { get; set; }


        public ICollection<CategoryEntity> Categories = new List<CategoryEntity>();

        public ProductTypeEntity(string name)
        {
            Id = GenerateStringId(name);
            Name = name;
        }
    }
}
