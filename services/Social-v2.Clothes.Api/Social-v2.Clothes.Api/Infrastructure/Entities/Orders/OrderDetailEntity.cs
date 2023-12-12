namespace Social_v2.Clothes.Api.Infrastructure.Entities.Orders
{
    public class OrderDetailEntity: Entity<long>
    {
        public string OrderId { get; set; }

        public OrderEntity Order { get; set; }
    }
}
