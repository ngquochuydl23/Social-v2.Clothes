using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Orders
{
    public class OrderEntity : Entity
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public string FulfillmentStatus { get; set; }

        public DateTime CanceledAt { get; set; }

        public string PaymentStatus { get; set; }

        public long ShippingTotal { get; set; }

        public long DiscountTotal { get; set; }

        public int GiftCardTotal { get; set; }

        public long Total { get; set; }

        public virtual UserEntity Customer { get; set; }

        public virtual DeliveryAddressEntity DeliveryAddress { get; set; }

        public long DeliveryAddressId { get; set; }

        public long CustomerId { get; set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; set; } = new List<OrderDetailEntity>();
    }
}
