using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class AddUpdateLineItemDto
    {
        [Required]
        public string ProductVarientId { get; set; }


        [Required]
        public int Quantity { get; set; } = 1;

        public bool IsIncreasedBy { get; set; } = true;
    }
}
