using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class AddLineItemDto
    {
        [Required]
        public string ProductVarientId { get; set; }


        [Required]
        public int Quantity { get; set; } = 1;
    }
}
