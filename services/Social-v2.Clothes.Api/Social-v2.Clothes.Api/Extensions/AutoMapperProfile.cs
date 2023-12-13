using AutoMapper;
using Social_v2.Clothes.Api.Dtos;
using Social_v2.Clothes.Api.Dtos.Category;
using Social_v2.Clothes.Api.Dtos.Collection;
using Social_v2.Clothes.Api.Dtos.DeliveryAddress;
using Social_v2.Clothes.Api.Dtos.Product;
using Social_v2.Clothes.Api.Dtos.Product.SkuValue;
using Social_v2.Clothes.Api.Dtos.Users;
using Social_v2.Clothes.Api.Dtos.Wishlist;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Collections;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists;

namespace Social_v2.Clothes.Api.Extensions
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SignUpRequestDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();
            CreateMap<CreateUpdateAddressDto, DeliveryAddressEntity>();
            CreateMap<DeliveryAddressEntity, DeliveryAddressDto>();

            CreateMap<ProductEntity, AdminProductDto>();
            CreateMap<ProductOptionEntity, ProductOptionDto>();
            CreateMap<ProductOptionValueEntity, ProductOptionValueDto>();
            CreateMap<ProductSkuEntity, ProductSkuDto>();
            CreateMap<SkuValueEntity, SkuValueDto>();

            CreateMap<WishlistEntity, WishlistDto>();
            CreateMap<CategoryEntity, CategoryDto>();
            CreateMap<CollectionEntity, CollectionDto>();
        }
    }
}
