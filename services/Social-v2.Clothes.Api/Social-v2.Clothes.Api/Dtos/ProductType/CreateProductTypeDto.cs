using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.ProductType
{
    public class CreateProductTypeDto
    {
        [Required]
        public string Name { get; set; }    
    }
}
