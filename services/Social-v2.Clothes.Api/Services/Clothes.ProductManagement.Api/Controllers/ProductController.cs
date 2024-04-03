using AutoMapper;
using Clothes.Commons;
using Clothes.Commons.Seedworks;
using Clothes.ProductManagement.Api.Infrastructure.Entities.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Clothes.ProductManagement.Api.Controllers
{
    [Authorize]
    [Route("product-api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IEfRepository<ProductEntity, string> _productRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(
            IEfRepository<ProductEntity, string> productRepo,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(httpContextAccessor)
        {
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("/Store/Product")]
        public IActionResult GetStoreProduct()
        {
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/Admin/Product")]
        public IActionResult GetAdminProduct()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

     
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
