using Clothes.Commons;
using System.Diagnostics.CodeAnalysis;

namespace Clothes.Order.Api.Dtos
{
    public class OrderDto : Dto<string>
    {
        public string Status { get; set; }

        public string FulfillmentStatus { get; set; }

        public DateTime? CanceledAt { get; set; }

        public string PaymentStatus { get; set; }

        public long ShippingTotal { get; set; }

        public long DiscountTotal { get; set; }

        public int GiftCardTotal { get; set; }

        public long Subtotal { get; set; }

        public long Total { get; set; }

        public string CreatedFrom { get; set; }

        public double TaxRate { get; set; }

        public CustomerDto Customer { get; set; }

        public ShippingAddressDto ShippingAddress { get; set; }

        public ICollection<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();
    }
}
