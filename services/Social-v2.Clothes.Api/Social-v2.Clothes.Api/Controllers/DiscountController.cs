using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos;
using Social_v2.Clothes.Api.Infrastructure.Entities.Discounts;
using Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : BaseController
    {

        private readonly IMapper _mapper;
        private readonly IRepository<DiscountEntity> _discountRepo;
        private readonly IRepository<StockLocationInventoryEntity> _stockLocationInventoryRepo;
        public DiscountController(
            IMapper mapper,
            IRepository<DiscountEntity> discountRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _discountRepo = discountRepo;
        }

        [HttpGet]
        public IActionResult GetDiscounts(
            [FromQuery] string ruleType,
            [FromQuery] string ruleAllocation,
            [FromQuery] bool isDisabled,
            [FromQuery] bool isDynamic)
        {



            return Ok();
        }

        [HttpGet("{code}")]
        public IActionResult GetDiscountByCode(string code)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateDiscount([FromBody] CreateDiscountDto value)
        {
            var discount = new DiscountEntity(
                value.Code,
                value.StartsAt,
                value.EndsAt,
                value.IsDisabled,
                value.UsageLimit,
                value.RuleType,
                value.RuleAllocation,
                value.RuleValue,
                value.RuleDescription);

            discount = _discountRepo.Insert(discount);
            return Ok();     
        }

        [HttpPut("{code}")]
        public IActionResult EditCollection(string code, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{code}")]
        public IActionResult DeleteCollection(string code)
        {
            return Ok();
        }
    }
}
