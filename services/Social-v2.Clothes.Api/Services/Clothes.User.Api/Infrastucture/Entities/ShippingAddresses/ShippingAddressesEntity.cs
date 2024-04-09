using Clothes.Commons.Seedworks;
using Clothes.User.Api.Infrastucture.Entities.Users;
using System.Diagnostics.CodeAnalysis;

namespace Clothes.User.Api.Infrastucture.Entities.ShippingAddresses
{
    public class ShippingAddressEntity : Entity<long>
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string ProvinceOrCity { get; set; }

        public string District  { get; set; }

        public string WardOrCommune { get; set; }

        public string AddressDetail { get; set; }

        public string AddressType { get; set; }
        public Boolean IsDefaultAddress { get; set; } = false;
        public long UserId { get; set; }

        public virtual UserEntity User { get; set; }

        public ShippingAddressEntity() { }

        public ShippingAddressEntity(string name, string phoneNumber, string provinceOrCity, string district, string wardOrCommune, string addressDetail, string addressType, bool isDefaultAddress, long userId, UserEntity user)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            ProvinceOrCity = provinceOrCity;
            District = district;
            WardOrCommune = wardOrCommune;
            AddressDetail = addressDetail;
            AddressType = addressType;
            IsDefaultAddress = isDefaultAddress;
            UserId = userId;
            User = user;
        }
    }
}
