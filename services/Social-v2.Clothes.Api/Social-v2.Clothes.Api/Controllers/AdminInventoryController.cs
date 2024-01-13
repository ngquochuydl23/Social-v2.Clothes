using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Inventory;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;


namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/admin/inventory")]
    [ApiController]
    public class AdminInventoryController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<InventoryEntity> _inventoryRepo;
        private readonly IRepository<ProductVarientEntity> _productVarientRepo;

        public AdminInventoryController(
            IMapper mapper,
            IRepository<InventoryEntity> inventoryRepo,
            IRepository<ProductVarientEntity> productVarientRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _inventoryRepo = inventoryRepo;
            _productVarientRepo = productVarientRepo;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetInventories([FromQuery] bool outOfStock)
        {
            var inventories = _inventoryRepo
                .GetQueryableNoTracking()
                .Include(x => x.ProductVarient)
                .ThenInclude(varient => varient.Product)
                .Where(x => !x.ProductVarient.Product.IsDeleted)
                .Where(x => outOfStock ? x.StockedQuantity == 0 : x.StockedQuantity != 0)
                .ToList();

            return Ok(_mapper.Map<ICollection<InventoryDto>>(inventories));
        }


        [HttpPut("{productVarientId}")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult AdjustStock(string productVarientId, [FromBody] AdjustInventoryDto value)
        {
            var inventory = _inventoryRepo
                .GetQueryable()
                .Include(x => x.ProductVarient)
                .ThenInclude(varient => varient.Product)
                .FirstOrDefault(x => x.ProductVarientId.Equals(productVarientId)
                    && !x.ProductVarient.Product.IsDeleted)
                        ?? throw new AppException("Product varient does not exist");

            inventory.StockedQuantity += value.Quantity;

            _inventoryRepo.SaveChanges();

            return Ok(_mapper.Map<InventoryDto>(inventory));
        }
    }
}
