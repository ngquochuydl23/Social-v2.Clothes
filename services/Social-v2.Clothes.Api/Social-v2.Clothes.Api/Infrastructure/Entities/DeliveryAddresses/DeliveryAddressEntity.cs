using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses
{
    public class DeliveryAddressEntity: Entity<long>
    {
        [NotNull]
        [MaxLength(DeliverAddressConstants.NameMaxLength)]
        public string Name { get; set; }

        [NotNull]
        [MaxLength(DeliverAddressConstants.PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [NotNull]
        [MaxLength(DeliverAddressConstants.DetailAddressMaxLength)]
        public string DetailAddress { get; set; }

        [NotNull]
        [MaxLength(DeliverAddressConstants.ProvinceOrCityMaxLength)]
        public string ProvinceOrCity { get; set; }

        [NotNull]
        [MaxLength(DeliverAddressConstants.DistrictMaxLength)]
        public string District { get; set; }

        [NotNull]
        [MaxLength(DeliverAddressConstants.WardOrCommuneMaxLength)]
        public string WardOrCommune { get; set; }

        public bool IsDefault { get; set; } = false;

        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }
    }
}

