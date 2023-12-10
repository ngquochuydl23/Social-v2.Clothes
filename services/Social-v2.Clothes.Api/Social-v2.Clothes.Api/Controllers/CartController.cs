using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Dtos.Cart;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Repository;
using System.Security.Claims;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpContext _httpContext;
        private readonly IMapper _mapper;

        public CartController(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _httpContext = httpContextAccessor.HttpContext;
            _mapper = mapper;
        }

        private long Id => long.Parse(_httpContext.User.FindFirstValue("id"));

        [HttpGet]
        public IActionResult GetAllCart()
        {

            return Ok();
        }

        [HttpPost]
        public IActionResult CreateNewCart([FromBody] CreateCardDto value)
        {


            return Ok(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
