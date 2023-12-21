using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Discounts;
using Social_v2.Clothes.Api.Infrastructure.Entities.Discounts;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<DiscountEntity> _discountRepo;
        private readonly IRepository<DiscountConditionEntity> _discountConditionRepo;
        public DiscountController(
            IMapper mapper,
            IRepository<DiscountEntity> discountRepo,
            IRepository<DiscountConditionEntity> discountConditionRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _discountRepo = discountRepo;
            _discountConditionRepo = discountConditionRepo;
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
            var discount = _discountRepo
                .GetQueryableNoTracking()
                .Include(x => x.Condition)
                .FirstOrDefault(x => x.Code.Equals(code) && !x.IsDeleted)
                ?? throw new AppException("Discount does not exist");
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

        [HttpPost("discountCode/condition")]
        public IActionResult AddCondition(string discountCode, [FromBody] AddDiscountConditionDto value)
        {
            var discount = _discountRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Code.Equals(discountCode) && !x.IsDeleted)
                ?? throw new AppException("Discount does not exist");

            if (discount.IsDisabled)
                throw new AppException("Discount is disabled");

            var condition = new DiscountConditionEntity(discount.Code, value.Operator);

            foreach (var appliedProductId in value.AppliedProducts)
            {
                condition.DiscountCondtionProducts.Add(
                    new ProductDiscountConditionEntity(condition.DiscountCode, appliedProductId));
            }

            condition = _discountConditionRepo.Insert(condition);

            return Ok();
        }

        [HttpPut("discountCode/condition")]
        public IActionResult UpdateCondition(string discountCode, [FromBody] AddDiscountConditionDto value)
        {
            var discount = _discountRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Code.Equals(discountCode) && !x.IsDeleted)
                ?? throw new AppException("Discount does not exist");

            if (discount.IsDisabled)
                throw new AppException("Discount is disabled");

            return Ok();
        }

        [HttpDelete("discountCode/condition")]
        public IActionResult DeleteCondition(string discountCode)
        {
            var discount = _discountRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Code.Equals(discountCode) && !x.IsDeleted)
                ?? throw new AppException("Discount does not exist");

            if (discount.IsDisabled)
                throw new AppException("Discount is disabled");

            return Ok();
        }

        [HttpPut("{code}")]
        public IActionResult EditDiscount(string code, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{code}")]
        public IActionResult DeleteDiscount(string code)
        {
            return Ok();
        }
    }
}
