using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.DeliveryAddress
{
    public class DeliveryAddressDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string DetailAddress { get; set; }

        public string ProvinceOrCity { get; set; }

        public string District { get; set; }

        public string WardOrCommune { get; set; }

        public bool IsDefault { get; set; } = false;
    }
}
