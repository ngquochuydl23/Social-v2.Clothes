﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Social_v2.Clothes.Api.Dtos.Wishlist;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using System.Security.Claims;

namespace Social_v2.Clothes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistController : BaseController
    {
        private readonly IRepository<WishlistEntity> _wishlistRepo;
        private readonly IRepository<ProductVarientEntity> _productVarientRepo;
        private readonly IMapper _mapper;

        public WishlistController(
            IRepository<WishlistEntity> wishlistRepo,
            IRepository<ProductVarientEntity> productVarientRepo,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper) : base(httpContextAccessor)
        {
            _wishlistRepo = wishlistRepo;
            _productVarientRepo = productVarientRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetWishlists()
        {
            var wishlists = _wishlistRepo
                .GetQueryableNoTracking()
                .Include(x => x.ProductSku)
                .Where(x => x.CustomerId == Id && !x.IsDeleted)
                .ToList();

            return Ok(_mapper.Map<ICollection<WishlistDto>>(wishlists));
        }

        [HttpPost]
        public IActionResult AddToWishlist([FromBody] AddToWishlistDto value)
        {
            var productVarient = _productVarientRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(value.ProductVarientId) && !x.IsDeleted)
                    ?? throw new AppException("Varient is not exist");


            var wishlist = _wishlistRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.ProductSkuId.Equals(productVarient.Id) && x.CustomerId == Id && !x.IsDeleted);

            if (wishlist != null)
                throw new AppException("Wishlist with varient is already exist");


            wishlist = _wishlistRepo.Insert(new WishlistEntity(productVarient.Id, Id));
            wishlist.ProductSku = productVarient;

            return Ok(_mapper.Map<WishlistDto>(wishlist));
        }

        [HttpDelete]
        public IActionResult RemoveFromWishlist([FromQuery] string productSkuId)
        {
            var productVarient = _productVarientRepo
            .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(productSkuId))
                    ?? throw new AppException("Varient is not exist");

            var wishlist = _wishlistRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.ProductSkuId.Equals(productVarient.Id) && x.CustomerId == Id && !x.IsDeleted)
                ?? throw new AppException("Wishlist with sku is not exist");


            _wishlistRepo.Delete(wishlist.Id);
            return Ok();
        }
    }
}
