using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Orders
{
    public class OrderEntity : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string OrderNo { get; private set; }

        public string Status { get; set; }

        public string FulfillmentStatus { get; set; }

        public DateTime? CanceledAt { get; set; }

        public string? PaymentStatus { get; set; }

        public long ShippingTotal { get; set; }

        public long DiscountTotal { get; set; }

        public int GiftCardTotal { get; set; }

        public long Subtotal { get; set; }

        public long Total { get; set; }

        public double TaxRate { get; set; }

        public virtual UserEntity Customer { get; set; }

        public virtual DeliveryAddressEntity DeliveryAddress { get; set; }

        public long DeliveryAddressId { get; set; }

        public long CustomerId { get; set; }

        public ICollection<OrderDetailEntity> OrderDetails { get; set; } = new List<OrderDetailEntity>();


        public OrderEntity(long customerId, long deliveryAddressId)
        {
            CustomerId = customerId;
            DeliveryAddressId = deliveryAddressId;
            OrderNo = "Social-v2.Clothes.Order_" + CustomerId + "_" + CreateAt.ToString("yyyyMMddHHmmss");

            Status = "Pending";
            FulfillmentStatus = "Started";

            ShippingTotal = 0;
            DiscountTotal = 0;
            GiftCardTotal = 0;
            Subtotal = 0;
            Total = 0;
        }
    }
}
