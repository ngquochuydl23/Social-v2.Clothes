using Social_v2.Clothes.Api.Dtos.Customer;
using Social_v2.Clothes.Api.Dtos.DeliveryAddress;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Dtos.Order
{
    public class OrderDto
    {
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

        public CustomerDto Customer { get; set; }

        public DeliveryAddressDto DeliveryAddress { get; set; }
    }
}
