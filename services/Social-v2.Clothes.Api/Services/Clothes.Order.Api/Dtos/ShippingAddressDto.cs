namespace Clothes.Order.Api.Dtos
{
    public class ShippingAddressDto
    {
        public string PhoneNumber { get; set; }

        public string DetailAddress { get; set; }

        public string ProvinceOrCity { get; set; }

        public string District { get; set; }

        public string WardOrCommune { get; set; }
    }
}
