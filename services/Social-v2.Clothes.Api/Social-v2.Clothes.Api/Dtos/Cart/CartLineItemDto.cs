using Social_v2.Clothes.Api.Dtos.Product;

namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class CartLineItemDto
    {
        public long Id { get; set; }

        public long CartId { get; set; }


        public int Quantity { get; set; }


        public ProductVarientDto ProductVarient { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
