using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos.Inventory;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Repository;


namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class AdminInventoryController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<InventoryEntity> _inventoryRepo;
        public AdminInventoryController(
            IMapper mapper,
            IRepository<InventoryEntity> inventoryRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _inventoryRepo = inventoryRepo;
        }

        [HttpGet]
        public IActionResult GetInventorySkus()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetInventorySku(string id)
        {
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
