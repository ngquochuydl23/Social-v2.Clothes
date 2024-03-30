using Clothes.Commons.Seedworks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Clothes.ProductManagement.Api.Infrastructure.Entities.Products;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTypes
{
    public class ProductTypeEntity : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Id { get; set; }

        public string Title { get; set; }

        public ICollection<ProductEntity> Products {  get; set; } = new List<ProductEntity>();

        public ProductTypeEntity() { }

        public ProductTypeEntity(string title)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
        }
    }
}
