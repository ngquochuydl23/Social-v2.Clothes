using Social_v2.Clothes.Api.Dtos.Product;

namespace Social_v2.Clothes.Api.Dtos.Wishlist
{
    public class WishlistDto
    {
        public long Id { get; set; }

        public ProductSkuDto ProductSku { get; set; }
    }
}
