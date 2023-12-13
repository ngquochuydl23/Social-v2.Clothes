using AutoMapper;
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
    [Route("api/store/[controller]")]
    [ApiController]
    public class StoreWishlistController : BaseController
    {
        private readonly IRepository<WishlistEntity> _wishlistRepo;
        private readonly IRepository<ProductSkuEntity> _productSkuRepo;
        private readonly IMapper _mapper;

        public StoreWishlistController(
            IRepository<WishlistEntity> wishlistRepo,
            IRepository<ProductSkuEntity> productSkuRepo,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper) : base(httpContextAccessor)
        {
            _wishlistRepo = wishlistRepo;
            _productSkuRepo = productSkuRepo;
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
            var productSku = _productSkuRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(value.ProductSkuId) && !x.IsDeleted)
                    ?? throw new AppException("Sku is not exist");


            var wishlist = _wishlistRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.ProductSkuId.Equals(productSku.Id) && x.CustomerId == Id && !x.IsDeleted);

            if (wishlist != null)
                throw new AppException("Wishlist with sku is already exist");


            wishlist = _wishlistRepo.Insert(new WishlistEntity(productSku.Id, Id));
            wishlist.ProductSku = productSku;

            return Ok(_mapper.Map<WishlistDto>(wishlist));
        }

        [HttpDelete]
        public IActionResult RemoveFromWishlist([FromQuery] string productSkuId)
        {
            var productSku = _productSkuRepo
            .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(productSkuId))
                    ?? throw new AppException("Sku is not exist");

            var wishlist = _wishlistRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.ProductSkuId.Equals(productSku.Id) && x.CustomerId == Id)
                ?? throw new AppException("Wishlist with sku is not exist");


            _wishlistRepo.Delete(wishlist.Id);

            return Ok();
        }
    }
}
