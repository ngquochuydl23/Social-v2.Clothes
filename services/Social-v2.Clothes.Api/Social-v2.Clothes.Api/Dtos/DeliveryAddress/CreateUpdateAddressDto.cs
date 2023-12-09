using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Dtos.DeliveryAddress
{
    public class CreateUpdateAddressDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string DetailAddress { get; set; }


        [Required]
        public string ProvinceOrCity { get; set; }

        [Required]
        public string District { get; set; }

        [Required]
        public string WardOrCommune { get; set; }

        [Required]
        public bool IsDefault { get; set; } = false;
    }
}
