using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Product;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpContext _httpContext;
        private readonly IRepository<ProductEntity> _productRepo;
        private readonly IMapper _mapper;

        public ProductController(
            IRepository<ProductEntity> productRepo,
            IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [HttpGet("admin")]
        public IActionResult GetProductsInAdmin()
        {
            
            return Ok();
        }

        [HttpGet("admin/{id}")]
        public IActionResult GetProductInAdmin(string id)
        {
            var product = _productRepo
                .GetQueryableNoTracking()
                .Include(x => x.ProductMedias)
                .FirstOrDefault(x => x.Id.Equals(id))
                    ?? throw new AppException("Product is null");

            return Ok(_mapper.Map<AdminProductDto>(product));
        }

        [HttpPost("admin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult CreateProduct([FromBody] CreateProductDto value)
        {
            var varients = value.Varients.Select(x => {
                return new ProductVarientEntity()
                {
                    Title = x.Title,

                };
            });


            return Ok(value);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult EditProduct(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("/store/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
