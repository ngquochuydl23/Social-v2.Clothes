using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class CreateCartItemDto
    {
        [Required]
        public string SkuId { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
