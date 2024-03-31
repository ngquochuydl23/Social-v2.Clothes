using AutoMapper;
using Clothes.Commons.Exceptions;
using Clothes.Commons.Seedworks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Social_v2.Clothes.Api.Dtos.Cart;
using Social_v2.Clothes.Api.Infrastructure;
using Social_v2.Clothes.Api.Infrastructure.Entities.Cart;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Orders;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/store/Cart")]
    [ApiController]
    public class StoreCartController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CartEntity> _cartRepo;
        private readonly IRepository<UserEntity> _userRepo;
        private readonly IRepository<ProductVarientEntity> _productVarientRepo;
        private readonly IRepository<OrderEntity> _orderRepo;
        private readonly IRepository<DeliveryAddressEntity> _deliveryAddressRepo;

        public StoreCartController(
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

        [HttpGet("MyCart")]
        [Authorize]
        public IActionResult GetCart()
        {
            var cart = _cartRepo
                .GetQueryableNoTracking()
                .Include(x => x.Customer)
                .Include(x => x.CartItems)
                .ThenInclude(item => item.ProductVarient)
                .ThenInclude(productVarient => productVarient.Product)

                .FirstOrDefault(x => x.CustomerId == Id && !x.IsDeleted)
                    ?? throw new AppException("Cart does not exist");

            return Ok(_mapper.Map<CartDto>(cart));
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreateCart()
        {
            if (_cartRepo
                .GetQueryableNoTracking()
                .Where(x => x.CustomerId == Id && !x.IsDeleted)
                .Any())
            {
                throw new AppException("This customer already had a cart");
            }

            return Ok(_mapper.Map<CartDto>(_cartRepo.Insert(new CartEntity(Id))));
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

        [HttpPost("{id}/AddCartItem")]
        public IActionResult AddCartItem(long id, [FromBody] AddUpdateLineItemDto value)
        {
            var cart = _cartRepo
                .GetQueryable()
                .Include(x => x.CartItems)
                .FirstOrDefault(x => x.Id == id && !x.IsDeleted)
                    ?? throw new AppException("Cart does not exist");

            if (string.IsNullOrEmpty(value.ProductVarientId))
            {
                throw new AppException("ProductVarientId must not empty");
            }
                

            if (value.Quantity <= 0)
            {
                throw new AppException("Quantity must be greater than 0");
            }


            var productVarient = _productVarientRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(value.ProductVarientId) && !x.IsDeleted)
                    ?? throw new AppException("Product varient does not exist");

            var cartItem = cart.CartItems.FirstOrDefault(x => x.ProductVarientId.Equals(productVarient.Id));

            if (cartItem == null)
            {
                cartItem = new CartItemEntity(value.ProductVarientId, value.Quantity);

                cart.CartItems.Add(cartItem);
                cart.LastUpdate = DateTime.Now;
            }
            else
            {
                cartItem.Quantity += value.Quantity;
                cartItem.LastUpdate = DateTime.Now;
            }

            cart.LastUpdate = DateTime.Now;

            _cartRepo.SaveChanges();

            return Ok(_mapper.Map<CartItemDto>(cartItem));
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

            var cartItem = cart.CartItems.FirstOrDefault(x => x.Id == lineItemId)
                ?? throw new AppException("Line item does not exist");

            cartItem.LastUpdate = DateTime.Now;
            cartItem.Quantity = value.IsIncreasedBy
                ? cartItem.Quantity += value.Quantity
                : cartItem.Quantity = value.Quantity;

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
               .ThenInclude(cartItem => cartItem.ProductVarient)
               .ThenInclude(proVarient => proVarient.Inventory)
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

                foreach (var lineItem in cart.CartItems)
                {
                    // -> create OrderDetail from CartItem

                    var orderDetail = new OrderDetailEntity()
                    {
                        OrderId = order.OrderNo,

                        ProductVarientId = lineItem.ProductVarientId,

                        Quantity = lineItem.Quantity,
                        ProductId = lineItem.ProductVarient.ProductId,
                        Subtotal = (long)(lineItem.ProductVarient.Price * lineItem.Quantity),


                        // *** CACULATE 

                        // TaxTotal
                        // DiscountTotal
                        // Total
                    };

                    order.OrderDetails.Add(orderDetail);

         

                    // -> adjust inventory
                    var inventory = lineItem.ProductVarient.Inventory;

                    inventory.StockedQuantity -= lineItem.Quantity;
                    inventory.ReservedQuantity += lineItem.Quantity;



                }

                _cartRepo.SaveChanges();
                _orderRepo.Insert(order);
                _unitOfWork.Complete();
            }
            return Ok(order);
        }
    }
}
