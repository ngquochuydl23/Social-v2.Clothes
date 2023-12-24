using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Cart
{
    public class CartItemEntity : Entity<long>
    {
        public long CartId { get; set; }

        public string ProductVarientId { get; set; }

        public virtual CartEntity Cart { get; set; }

        public virtual ProductVarientEntity ProductVarient { get; set; }

        public int Quantity { get; set; } = 0;

        public CartItemEntity(string productVarientId, int quantity)
        {
            ProductVarientId = productVarientId;
            Quantity = quantity;
            CreateAt = DateTime.Now;
        }
    }
}
