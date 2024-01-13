using AutoMapper;
using Social_v2.Clothes.Api.Dtos;
using Social_v2.Clothes.Api.Dtos.Cart;
using Social_v2.Clothes.Api.Dtos.Category;
using Social_v2.Clothes.Api.Dtos.Collection;
using Social_v2.Clothes.Api.Dtos.Customer;
using Social_v2.Clothes.Api.Dtos.DeliveryAddress;
using Social_v2.Clothes.Api.Dtos.Inventory;
using Social_v2.Clothes.Api.Dtos.Invites;
using Social_v2.Clothes.Api.Dtos.Order;
using Social_v2.Clothes.Api.Dtos.Product;
using Social_v2.Clothes.Api.Dtos.ProductType;
using Social_v2.Clothes.Api.Dtos.Users;
using Social_v2.Clothes.Api.Dtos.Wishlist;
using Social_v2.Clothes.Api.Infrastructure.Entities.Cart;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Collections;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Invites;
using Social_v2.Clothes.Api.Infrastructure.Entities.Orders;
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

            CreateMap<ProductEntity, ProductDto>();
            CreateMap<ProductEntity, DetailProductDto>()
                .ForMember(des => des.Categories,
                    act => act.MapFrom(src => src.CategoryProducts.Select(x => x.Category)));

            CreateMap<TagEntity, TagDto>();

            CreateMap<ProductVarientMediaEntity, ProductVarientMediaDto>();

            CreateMap<ProductOptionEntity, ProductOptionDto>();
            CreateMap<ProductOptionValueEntity, ProductOptionValueDto>();
            CreateMap<ProductVarientEntity, ProductVarientDto>()
                  .ForMember(des => des.ProductTitle,
                            act => act.MapFrom(src => src.Product.Title))
                  .ForMember(des => des.Thumbnail,
                            act => act.MapFrom(src => src.Product.Thumbnail));

            CreateMap<WishlistEntity, WishlistDto>();
            CreateMap<CategoryEntity, CategoryDto>();
            CreateMap<CollectionEntity, CollectionDto>();
            CreateMap<UserEntity, CustomerDto>(); 
            CreateMap<UserEntity, CustomerDetailDto>();

            CreateMap<ProductTypeEntity, ProductTypeDto>();
         

            CreateMap<CartEntity, CartDto>();
            CreateMap<CartItemEntity, CartItemDto>();

            CreateMap<UserEntity, CartCustomerDto>();
            CreateMap<UserEntity, EmployeeDto>(); 
            CreateMap<InventoryEntity, InventoryDto>();

            CreateMap<ProductVarientEntity, ProductVarientInventoryDto>()
                .ForMember(des => des.Thumbnail,
                    act => act.MapFrom(src => src.Product.Thumbnail))
                .ForMember(des => des.ProductTitle,
                    act => act.MapFrom(src => src.Product.Title));


            CreateMap<OrderEntity, OrderDto>();
        }
    }
}
