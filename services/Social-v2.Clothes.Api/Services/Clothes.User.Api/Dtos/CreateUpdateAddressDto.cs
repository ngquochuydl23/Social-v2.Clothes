using System.ComponentModel.DataAnnotations;

namespace Clothes.User.Api.Dtos
{
    public class CreateUpdateAddressDto
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string ProvinceOrCity { get; set; }

        public string District { get; set; }

        public string WardOrCommune { get; set; }

        public string AddressDetail { get; set; }

        public string AddressType { get; set; }
        public Boolean IsDefaultAddress { get; set; } = false;
    }
}
