using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists
{
    public class WishlistEntity : Entity<long>
    {
        public string ProductVarientId { get; set; }

        public ProductVarientEntity ProductVarient { get; set; }

        public UserEntity Customer { get; set; }

        public long CustomerId { get; set; }


        public WishlistEntity(string productVarientId, long customerId)
        {
            ProductVarientId = productVarientId;
            CustomerId = customerId;
        }
    }
}
