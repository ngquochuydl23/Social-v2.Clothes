﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Cart;
using Social_v2.Clothes.Api.Infrastructure;
using Social_v2.Clothes.Api.Infrastructure.Entities.Cart;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Orders;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CartEntity> _cartRepo;
        private readonly IRepository<UserEntity> _userRepo;
        private readonly IRepository<ProductVarientEntity> _productVarientRepo;
        private readonly IRepository<OrderEntity> _orderRepo;
        private readonly IRepository<DeliveryAddressEntity> _deliveryAddressRepo;
        public CartController(
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IRepository<CartEntity> cartRepo,
            IRepository<UserEntity> userRepo,
            IRepository<OrderEntity> orderRepo,
            IRepository<ProductVarientEntity> productVarientRepo,
            IRepository<DeliveryAddressEntity> deliveryAddressRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _cartRepo = cartRepo;
            _userRepo = userRepo;
            _productVarientRepo = productVarientRepo;
            _deliveryAddressRepo = deliveryAddressRepo;
            _orderRepo = orderRepo;
            _unitOfWork = unitOfWork;
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


        [HttpGet("{id}/lineItems")]
        public IActionResult GetLineItems(long id)
        {
            var cart = _cartRepo
               .GetQueryableNoTracking()
               .Include(x => x.CartItems)
               .FirstOrDefault(x => x.Id == id && !x.IsDeleted)
               .CartItems
               .ToList()
                 ?? throw new AppException("Cart does not exist");

            return Ok(cart);
        }

        [HttpPost("{id}/lineItems")]
        public IActionResult AddLineItem(long id, [FromBody] AddUpdateLineItemDto value)
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

        [HttpPut("{id}/lineItems/{lineItemId}")]
        public IActionResult UpdateLineItem(long id, long lineItemId, [FromBody] AddUpdateLineItemDto value)
        {
            var cart = _cartRepo
                .GetQueryable()
                .Include(x => x.CartItems)
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

            var lineItem = cart.CartItems.FirstOrDefault(x => x.Id == lineItemId)
                ?? throw new AppException("Line item does not exist");

            lineItem.Quantity = value.Quantity;
            lineItem.LastUpdate = DateTime.Now;

            cart.LastUpdate = DateTime.Now;
            _cartRepo.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}/lineItems/{lineItemId}")]
        public IActionResult DeleteLineItem(long id, long lineItemId, [FromBody] AddUpdateLineItemDto value)
        {
            var cart = _cartRepo
                .GetQueryable()
                .Include(x => x.CartItems)
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

            var lineItem = cart.CartItems.FirstOrDefault(x => x.Id == lineItemId)
                ?? throw new AppException("Line item does not exist");

            cart.CartItems.Remove(lineItem);
            cart.LastUpdate = DateTime.Now;
            _cartRepo.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCart(long id)
        {
            var cart = _cartRepo
                .GetQueryable()
                .Include(x => x.CartItems)
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted)
               ?? throw new AppException("Cart does not exist");

            _cartRepo.Delete(cart);
            return Ok();
        }

        [HttpPost("{cartId}/CompleteCart")]
        [Authorize]
        public IActionResult CompleteCart(long cartId, [FromBody] CompleteCartDto value)
        {
            var cart = _cartRepo
               .GetQueryable()
               .Include(x => x.CartItems)
               .FirstOrDefault(x => x.Id == cartId && !x.IsDeleted)
              ?? throw new AppException("Cart does not exist");

            var customer = _userRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id == Id)
                    ?? throw new AppException("User does not exist");

            var deliveryAddress = _deliveryAddressRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id == value.DeliveryAddressId)
                    ?? throw new AppException("Delivery address does not exist");

            var order = new OrderEntity(customer.Id, deliveryAddress.Id);

            using (_unitOfWork.Begin())
            {

                //  add line items  from cart line items
                foreach (var lineItem in cart.CartItems)
                {
                    var orderDetail = new OrderDetailEntity()
                    {

                    };

                    order.OrderDetails.Add(orderDetail);
                }


                //  adjust inventoy




                // payment



                _orderRepo.Insert(order);
                //_unitOfWork.Complete();
            }
            return Ok(order);
        }
    }
}
