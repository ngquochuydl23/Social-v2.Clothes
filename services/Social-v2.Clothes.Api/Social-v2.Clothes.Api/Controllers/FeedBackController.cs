using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Repository;


namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : BaseController
    {
        private readonly IMapper _mapper;

        public FeedBackController(
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
        }

        [HttpGet("shop/average")]
        public IActionResult GetAverageRatings()
        {
            return Ok();
        }

        [HttpGet("shop/customerReviews")]
        public IActionResult GetCustomerReviews(
            [FromQuery] DateTime from,
            [FromQuery] DateTime to)
        {
            return Ok();
        }
    }
}
