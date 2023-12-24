using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Cart
{
    public class CartEntity : Entity<long>
    {
        public virtual UserEntity? Customer { get; set; }

        public long? CustomerId { get; set; }

        public ICollection<CartItemEntity> CartItems { get; set; } = new List<CartItemEntity>();


        public CartEntity(long customerId)
        {
            CustomerId = customerId;
        }

        public CartEntity() { }
    }
}
