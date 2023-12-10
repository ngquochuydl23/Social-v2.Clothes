using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Wishlist
{
    public class AddToWishlistDto
    {
        [Required]
        public string ProductSkuId { get; set; }    
    }
}
