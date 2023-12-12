namespace Social_v2.Clothes.Api.Infrastructure.Entities.Orders
{
    public class OrderEntity: Entity
    {
        public string Id { get; set; }

        public string Status { get; set; }

        public DateTime CanceledAt { get; set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; set; } = new List<OrderDetailEntity>();
    }
}
