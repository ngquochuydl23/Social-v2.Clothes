using AutoMapper;
using Clothes.Commons.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Social_v2.Clothes.Api.Dtos.ProductType;
using Social_v2.Clothes.Api.Infrastructure.Entities.Discounts;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ProductTypeEntity> _productTypeRepo;

        public ProductTypeController(
            IRepository<ProductTypeEntity> productTypeRepo,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _productTypeRepo = productTypeRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult GetProductTypes()
        {
            var productTypes = _productTypeRepo
                .GetQueryableNoTracking()
                .Where(x => !x.IsDeleted)
                .OrderByDescending(x => x.CreateAt)
                .ToList();

            return Ok(_mapper.Map<ICollection<ProductTypeDto>>(productTypes));
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult AddProductType([FromBody] CreateProductTypeDto value)
        {
            if (_productTypeRepo.GetQueryableNoTracking()
                .FirstOrDefault(x => x.Name.Equals(value.Name) && !x.IsDeleted) == null)
                throw new AppException("Category is already exist");

            var productType = _productTypeRepo.Insert(new ProductTypeEntity(value.Name));

            return Ok(_mapper.Map<ProductTypeDto>(productType));
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
