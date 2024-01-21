using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Product;
using Social_v2.Clothes.Api.Dtos.Product.StoreProductDto;
using Social_v2.Clothes.Api.Infrastructure;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/store/Product")]
    [ApiController]
    public class StoreProductController : BaseController
    {
        private readonly IRepository<ProductEntity> _productRepo;
        private readonly IRepository<ProductVarientEntity> _productVarientRepo;
        private readonly IRepository<ProductOptionEntity> _productOptionRepo;
        private readonly IRepository<TagEntity> _tagRepo;
        private readonly IRepository<ProductTagEntity> _productTagRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StoreProductController(
            IRepository<ProductEntity> productRepo,
            IRepository<ProductVarientEntity> productVarientRepo,
            IRepository<ProductOptionEntity> productOptionRepo,
            IRepository<ProductTagEntity> productTagRepo,
            IRepository<VarientValueEntity> varientValueRepo,
            IRepository<TagEntity> tagRepo,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(httpContextAccessor)
        {
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
            _productTagRepo = productTagRepo;
            _productVarientRepo = productVarientRepo;
            _productOptionRepo = productOptionRepo;
            _tagRepo = tagRepo;
            _mapper = mapper;
        }


        [HttpGet("newArrivals")]
        [AllowAnonymous]
        public IActionResult GetNewArrivals()
        {
            var products = _productRepo
                .GetQueryableNoTracking()
                .Include(x => x.ProductVarients)
                .ThenInclude(productVarient => productVarient.VarientMedias)
                .Where(x => !x.IsDeleted)
                .ToList();

            return Ok(_mapper.Map<ICollection<StoreProductDto>>(products));
        }

        [HttpGet("topSales")]
        [AllowAnonymous]
        public IActionResult GetTopSales()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(string id)
        {
            var product = _productRepo
                .GetQueryableNoTracking()
                .Include(x => x.Collection)
                .Include(x => x.CategoryProducts)
                .Include(x => x.Options)
                .ThenInclude(opt => opt.OptionValues)
                .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                    ?? throw new AppException("Product does not exist");

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpGet("{id}/varient")]
        [AllowAnonymous]
        public IActionResult GetProductById(string id)
        {
            var queryParams = HttpContext.Request.Query;
            var product = _productRepo
                .GetQueryableNoTracking()
                .Include(x => x.VarientValues)
                .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                    ?? throw new AppException("Product does not exist");

            var productVarients = _productVarientRepo
                .GetQueryableNoTracking()
                .Include(x => x.VarientMedias)
                .Where(x => x.ProductId.Equals(id) && !x.IsDeleted)
                .ToArray();

            if (!queryParams.Any())
            {
                Ok(_mapper.Map<ProductVarientDto>(productVarients.FirstOrDefault()));
            }

            foreach (var query in queryParams)
            {
                productVarients = productVarients
                    .Where(x => x.QueryString.Contains($"{query.Key}={query.Value}"))
                    .ToArray();
            }

            if (!productVarients.Any())
                throw new AppException("Product Varient not found");

            return Ok(_mapper.Map<ProductVarientDto>(productVarients.FirstOrDefault()));
        }
    }
}
