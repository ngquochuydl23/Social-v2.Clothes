using AutoMapper;
using Clothes.User.Api.Dtos;
using Clothes.User.Api.Infrastucture.Entities.ShippingAddresses;
using Clothes.User.Api.Infrastucture.Entities.Users;

namespace Clothes.User.Api.Extensions
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CreateUpdateAddressDto, ShippingAddressEntity>();
            CreateMap<SignUpDto, UserEntity>();
        }
    }
}
