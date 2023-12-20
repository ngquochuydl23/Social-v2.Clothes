using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists
{
    public class WishlistEntity : Entity<long>
    {
        public string ProductSkuId { get; set; }

        public ProductVarientEntity ProductSku { get; set; }

        public UserEntity Customer { get; set; }

        public long CustomerId { get; set; }


        public WishlistEntity(string productSkuId, long customerId)
        {
            ProductSkuId = productSkuId;
            CustomerId = customerId;
        }
    }
}
