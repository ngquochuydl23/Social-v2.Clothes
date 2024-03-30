using Clothes.Commons.Seedworks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTypes
{
    public class ProductTypeEntity : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Id { get; set; }

        public string Title { get; set; }

        public ProductTypeEntity() { }

        public ProductTypeEntity(string title)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
        }

         
    }
}
