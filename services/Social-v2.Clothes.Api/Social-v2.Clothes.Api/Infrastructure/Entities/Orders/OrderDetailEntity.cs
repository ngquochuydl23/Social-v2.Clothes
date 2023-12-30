using Social_v2.Clothes.Api.Infrastructure.Entities.Cart;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Orders
{
    public class OrderDetailEntity: Entity<long>
    {
        public string OrderId { get; set; }

        public OrderEntity Order { get; set; }

        public string ProductVarientId { get; set; }

        public virtual ProductVarientEntity ProductVarient { get; set; }

        public int Quantity { get; set; }

        public long DiscountTotal { get; set; }

        public long Subtotal { get; set; }

        public long Total { get; set; }

        public string Thumbnail { get; set;  }
        
        public string Title { get; set; }


        public string Description { get; set; }

        public long TaxTotal { get; set; }


        public string ProductId { get; set; }
    }
}
