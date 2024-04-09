using Clothes.Commons.Seedworks;

namespace Clothes.Order.Api.Infrastructure.Entities
{
    public class OrderDetailEntity: Entity<long>
    {
        public string OrderId { get; set; }

        public virtual OrderEntity Order { get; set; }

        public virtual ProductValueObject Product { get; set; }
    }
}
