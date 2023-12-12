using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Social_v2.Clothes.Api.Dtos.Category;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.DeliveryAddresses;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {

        private readonly IRepository<CategoryEntity> _categoryRepo;
        private readonly IRepository<ProductEntity> _productRepo;
        private readonly IRepository<CategoryProductEntity> _cateProRepo;
        private readonly IMapper _mapper;

        public CategoryController(
            IMapper mapper,
            IRepository<CategoryEntity> categoryRepo,
            IRepository<ProductEntity> productRepo,
            IRepository<CategoryProductEntity> cateProRepo,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _cateProRepo = cateProRepo;
        }

        [HttpGet]
        public IActionResult GetAllCategories([FromQuery] bool? isActive)
        {
            var categories = _categoryRepo
              .GetQueryableNoTracking()
              .Where(x => !x.IsDeleted);

            return Ok(_mapper.Map<CategoryDto>(categories));
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto value)
        {
            var category = _categoryRepo
              .GetQueryableNoTracking()
              .FirstOrDefault(x => x.Name.Equals(value.Name) && !x.IsDeleted);

            if (category != null)
                throw new AppException("Category is already exist");

            category = _categoryRepo.Insert(new CategoryEntity(value.Name, value.Description, value.IsActive, value.ParentCategoryId, value.Handle));
            return Ok(_mapper.Map<CategoryDto>(category));
        }

        [HttpPut("{id}")]
        public IActionResult EditCategory(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepo
              .GetQueryableNoTracking()
              .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
               ?? throw new AppException("Category is not exist");

            _categoryRepo.Delete(category);
            return Ok();
        }

        [HttpGet("{id}/product")]
        public IActionResult AddProductToCategory(string id, [FromBody] AddProductToCategoryDto value)
        {
            var category = _categoryRepo
              .GetQueryableNoTracking()
              .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
               ?? throw new AppException("Category is not exist");

            var product = _productRepo
              .GetQueryableNoTracking()
              .FirstOrDefault(x => x.Id.Equals(value.ProductId) && !x.IsDeleted)
              ?? throw new AppException("Product is not exist");

            var categoryProduct = _cateProRepo.Insert(new CategoryProductEntity(category.Id, product.Id));

            return Ok();
        }
    }
}
