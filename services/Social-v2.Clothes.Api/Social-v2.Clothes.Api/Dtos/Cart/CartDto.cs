namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class CartDto
    {
        public long Id { get; set; }

        public long CustomerId {  get; set; }

        public DateTime CompletedAt { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime LastUpdate { get; set; }

        public ICollection<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    }
}
