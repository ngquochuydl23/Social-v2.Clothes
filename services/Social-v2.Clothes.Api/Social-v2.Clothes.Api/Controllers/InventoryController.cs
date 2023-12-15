using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Inventory;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;


namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<InventoryEntity> _inventoryRepo;
        private readonly IRepository<StockLocationInventoryEntity> _stockLocationInventoryRepo;
        public InventoryController(
            IMapper mapper,
            IRepository<InventoryEntity> inventoryRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _inventoryRepo = inventoryRepo;
        }

        [HttpGet]
        public IActionResult GetInventorySkus([FromQuery] string stockLocationId)
        {
            var inventories = _stockLocationInventoryRepo
                .GetQueryableNoTracking()
                .Include(x => x.Inventory)
                .Where(x => x.StockLocationId.Equals(stockLocationId))
                .ToList();

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetInventorySku(string id)
        {
            var inventory = _inventoryRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.ProductSkuId.Equals(id))
                    ?? throw new AppException("");
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateQuantity(string id, [FromBody] UpdateQuantityDto value)
        {
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateInventoyy(string id, [FromBody] UpdateInventoryDto value)
        {
            return Ok();
        }
    }
}
