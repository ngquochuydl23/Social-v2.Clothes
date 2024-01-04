using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Inventory;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
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
        private readonly IRepository<ProductVarientEntity> _productVarientRepo;

        public InventoryController(
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
        public IActionResult GetInventories()
        {
            var inventories = _inventoryRepo
                .GetQueryableNoTracking()
                .Include(x =>  x.ProductVarient)
                .ThenInclude(pVar => pVar.Product)
                .Include(x => x.ProductVarient)
                .ThenInclude(pVar => pVar.VarientMedias)
                .Where(x => !x.ProductVarient.Product.IsDeleted)
                .ToList();

            return Ok(_mapper.Map<ICollection<InventoryDto>>(inventories));
        }
    }
}
