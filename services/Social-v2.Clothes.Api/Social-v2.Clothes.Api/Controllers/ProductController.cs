using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Product;
using Social_v2.Clothes.Api.Infrastructure;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IRepository<ProductEntity> _productRepo;
        private readonly IRepository<ProductVarientEntity> _productSkuRepo;
        private readonly IRepository<ProductOptionEntity> _productOptionRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(
            IRepository<ProductEntity> productRepo,
            IRepository<ProductVarientEntity> productSkuRepo,
            IRepository<ProductOptionEntity> productOptionRepo,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork,
            IMapper mapper) : base(httpContextAccessor)
        {
            _productRepo = productRepo;
            _unitOfWork = unitOfWork;
            _productSkuRepo = productSkuRepo;
            _productOptionRepo = productOptionRepo;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _productRepo
              .GetQueryableNoTracking()
              .Include(x => x.Collection)
              .Where(x => !x.IsDeleted)
              .ToList();

            return Ok(_mapper.Map<ICollection<ProductDto>>(products));
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
                    ?? throw new AppException("Product is null");

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost("{id}/option")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult AddProductOption(string id, [FromBody] CreateOptionDto pOption)
        {
            var product = _productRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                    ?? throw new AppException("Product is null");
        
            var productOption = _productOptionRepo.Insert(CreateProductOption(pOption, product));
            return Ok(_mapper.Map<ProductOptionDto>(productOption));
        }

        [AllowAnonymous]
        [HttpGet("{id}/varients")]
        public IActionResult GetProductVarients(string id)
        {
            var productVarients = _productSkuRepo
                .GetQueryableNoTracking()
                .Include(x => x.VarientMedias)
                .Where(x => x.ProductId.Equals(id))
                .ToList();

            return Ok(_mapper.Map<ICollection<ProductVarientDto>>(productVarients));
        }

        [Authorize(Roles = UserConstants.AdministratorRole)]
        [HttpPut("{id}/varients")]
        public IActionResult AddProductVarient(string id, [FromBody] CreateUpdateProductVarientDto proVarient)
        {
            var product = _productRepo
               .GetQueryableNoTracking()
               .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                   ?? throw new AppException("Product is null");

            var productVarient = _productSkuRepo.Insert(CreateProductVarient(proVarient, product));

            return Ok(_mapper.Map<ProductVarientDto>(productVarient));
        }

        [HttpDelete("{id}/varients/{varientId}")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult DeleteProductSku(string id, string varientId)
        {
            var productVarient = _productSkuRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.ProductId.Equals(id) && x.Id.Equals(varientId) && !x.IsDeleted)
                    ?? throw new AppException("Sku is not exist");

            _productSkuRepo.Delete(productVarient);
            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult CreateProduct([FromBody] CreateProductDto value)
        {
            var product = new ProductEntity(
              value.Title,
              value.Subtitle,
              value.Handle,
              value.Description,
              value.Discountable,
              value.Thumbnail,
              value.CollectionId);


            using (_unitOfWork.Begin())
            {
                if (_productRepo
                    .GetQueryableNoTracking()
                    .FirstOrDefault(x => x.Id.Equals(product.Id)) != null)
                    throw new AppException("Product is already exist.");

                foreach (var pOption in value.Options)
                {
                    product.Options.Add(CreateProductOption(pOption, product));
                }

                product = _productRepo.Insert(product);

                foreach (var category in value.Categories)
                {
                    product.CategoryProducts.Add(new CategoryProductEntity(
                        category.CategoryId, 
                        product.Id));
                }

                foreach (var proVarient in value.ProductVarients)
                {
                    product.ProductVarients.Add(CreateProductVarient(proVarient, product));
                }
                    
                _productRepo.SaveChanges();
                _unitOfWork.Complete();
            }
            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPut("{id}/generalInfo")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult EditGeneralInfo(int id, [FromBody] EditGeneralInfoDto value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult Delete(string id)
        {
            var product = _productRepo
               .GetQueryableNoTracking()
               .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                   ?? throw new AppException("Product is null");

            _productRepo.Delete(product);
            return Ok();
        }

        private ProductOptionEntity CreateProductOption(CreateOptionDto pOption, ProductEntity product)
        {
            var productOption = new ProductOptionEntity(pOption.Title, product.Id);
            foreach (var optionValue in pOption.OptionValues)
            {
                productOption.OptionValues.Add(new ProductOptionValueEntity(optionValue));
            }   
            return productOption;
        }

        private ProductVarientEntity CreateProductVarient(
            CreateUpdateProductVarientDto pVarientInput,
            ProductEntity product)
        {
            var productVarient = new ProductVarientEntity(pVarientInput.Title, pVarientInput.Price, product.Id);

            foreach (var media in pVarientInput.ProductVarientMedias)
            {
                productVarient.VarientMedias.Add(new ProductVarientMediaEntity(
                    media.Url,
                    media.Mime,
                    productVarient.Id));
            }

            foreach (var varientValue in pVarientInput.VarientValues)
            {
                var option = product
                    .Options
                    .FirstOrDefault(x => x.Title.Equals(varientValue.Option))
                        ?? throw new AppException("Option is invalid");

                var optValue = option
                    .OptionValues
                    .FirstOrDefault(x => x.Value.Equals(varientValue.Value))
                        ?? throw new AppException("Option Value is invalid");

                productVarient.VarientValues.Add(new VarientValueEntity()
                {
                    ProductId = product.Id,
                    ProductOptionId = option.Id,
                    ProductOptionValueId = optValue.Id
                });
            }

            return productVarient;
        }
    }
}
