using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Clothes.Order.Api.Infrastructure.Entities
{
    public class ShippingAddressValueObject
    {
        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string PhoneNumber { get; set; }

        [NotNull]
        public string DetailAddress { get; set; }

        [NotNull]
        public string ProvinceOrCity { get; set; }

        [NotNull]
        public string District { get; set; }

        [NotNull]
        public string WardOrCommune { get; set; }
    }
}
