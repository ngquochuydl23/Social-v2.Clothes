using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Cart;
using Social_v2.Clothes.Api.Infrastructure.Entities.Cart;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CartController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CartEntity> _cartRepo;
        private readonly IRepository<UserEntity> _userRepo;
        private readonly IRepository<ProductVarientEntity> _productVarientRepo;
        public CartController(
            IMapper mapper,
            IRepository<CartEntity> cartRepo,
            IRepository<UserEntity> userRepo,
            IRepository<ProductVarientEntity> productVarientRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _cartRepo = cartRepo;
            _userRepo = userRepo;
            _productVarientRepo = productVarientRepo;
        }

        [HttpGet("{id}")]
        public IActionResult GetCart(long id)
        {
            var cart = _cartRepo
                .GetQueryableNoTracking()
                .Include(x => x.Customer)
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted)
               ?? throw new AppException("Cart does not exist");

            return Ok(_mapper.Map<CartDto>(cart));
        }

        [HttpPost]
        public IActionResult CreateCart([FromBody] CreateCartDto value)
        {
            if (value.CustomerId.HasValue)
            {
                var customerId = value.CustomerId.Value;

                if (customerId == 0)
                    throw new AppException("CustomerId is invalid");

                return Ok(_mapper.Map<CartDto>(_cartRepo.Insert(new CartEntity(customerId))));
            }

            return Ok(_mapper.Map<CartDto>(_cartRepo.Insert(new CartEntity())));
        }

        [HttpPut("{id}")]
        public IActionResult EditCart(long id, [FromBody] UpdateCartDto value)
        {
            var cart = _cartRepo.Find(id)
                ?? throw new AppException("Cart does not exist");

            if (value.CustomerId.HasValue)
            {
                var customerId = value?.CustomerId.Value;
                if (customerId == 0)
                    throw new AppException("CustomerId is invalid");

                var customer = _userRepo.Find(customerId)
                    ?? throw new AppException("Customer does not exist");

                cart.CustomerId = customer.Id;
            }
            cart = _cartRepo.Update(id, cart);
            return Ok(_mapper.Map<CartDto>(cart));
        }

        [HttpPost("{id}/lineItems")]
        public IActionResult AddLineItem(long id, [FromBody] AddLineItemDto value)
        {
            var cart = _cartRepo
                .GetQueryable()
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted)
               ?? throw new AppException("Cart does not exist");

            if (string.IsNullOrEmpty(value.ProductVarientId))
                throw new AppException("ProductVarientId must not empty");

            if (value.Quantity <= 0)
                throw new AppException("Quantity must be greater than 0");

            var productVarient = _productVarientRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(value.ProductVarientId) && !x.IsDeleted)
                    ?? throw new AppException("Product varient does not exist");


            cart.CartItems.Add(new CartItemEntity(value.ProductVarientId, value.Quantity));
            cart.LastUpdate = DateTime.Now;

            _cartRepo.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult RemoveCart(long id)
        {
            return Ok();
        }

        [HttpPatch("{id}/increaseQuantity")]
        public IActionResult IncreaseQuantity(long id)
        {
            return Ok();
        }

        [HttpPatch("{id}/decreaseQuantity")]
        public IActionResult DecreaseQuantity(long id)
        {
            return Ok();
        }
    }
}
