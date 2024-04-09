using Clothes.Commons.Seedworks;

namespace Clothes.Order.Api.Infrastructure.Entities
{
    public class OrderEntity: Entity
    {
        public string Id { get; set; }

        public virtual CustomerValueObject Customer { get; set; }

        public virtual ShippingAddressValueObject ShippingAddress { get; set; }

        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; } = new List<OrderDetailEntity>();
    }
}
