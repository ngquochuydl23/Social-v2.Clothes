using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Social_v2.Clothes.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/store/[controller]")]
    [ApiController]
    public class StoreProductController : BaseController
    {
        private readonly IRepository<ProductEntity> _productRepo;
        private readonly IRepository<ProductSkuEntity> _productSkuRepo;
        private readonly IMapper _mapper;

        public StoreProductController(
            IRepository<ProductEntity> productRepo,
            IRepository<ProductSkuEntity> productSkuRepo,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper) : base(httpContextAccessor)
        {
            _productRepo = productRepo;
            _productSkuRepo = productSkuRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StoreProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
