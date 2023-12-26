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
              .Where(x => !x.IsDeleted)
              .ToList();

            return Ok(_mapper.Map<ICollection<AdminProductDto>>(products));
        }

        [AllowAnonymous]
        [HttpGet("{id}/withOptionValue")]
        public IActionResult GetProductWithOptionValue([FromQuery] object queryParams)
        {


            return Ok(HttpContext.Request.Query);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(string id)
        {
            var product = _productRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                    ?? throw new AppException("Product is null");

            return Ok(_mapper.Map<AdminProductDto>(product));
        }

        [HttpPost("{id}/option")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult AddProductOption(string id, [FromBody] CreateOptionDto value)
        {
            var product = _productRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                    ?? throw new AppException("Product is null");

            var productOption = new ProductOptionEntity(value.Title, id);

            foreach (var optionValue in value.OptionValues)
                productOption.OptionValues.Add(new ProductOptionValueEntity(optionValue));

            productOption = _productOptionRepo.Insert(productOption);
            return Ok(_mapper.Map<ProductOptionDto>(productOption));
        }

        [AllowAnonymous]
        [HttpGet("sku/{skuId}/inventory")]
        public IActionResult GetProductSkuInInventory(string skuId)
        {
            return Ok();
        }

        [HttpPut("{id}/sku")]
        public IActionResult CreateProductSku(string id, [FromBody] CreateUpdateProductVarientDto value)
        {


            var product = _productRepo
               .GetQueryableNoTracking()
               .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                   ?? throw new AppException("Product is null");

            var productVarient = new ProductVarientEntity(value.Title, value.Price, product.Id);

            // add inventory in relation to sku
            productVarient.Inventory = new InventoryEntity(productVarient.Id);

            // add medias to each sku
            foreach (var media in value.ProductVarientMedias)
                productVarient.VarientMedias.Add(new ProductVarientMediaEntity(media.Url, media.Mime, productVarient.Id));

            // add sku value to each sku
            foreach (var inVarientValue in value.VarientValues)
            {
                var option = product.Options.FirstOrDefault(x => x.Title.Equals(inVarientValue.Option))
                    ?? throw new AppException("Option is invalid");

                var optValue = option.OptionValues.FirstOrDefault(x => x.Value.Equals(inVarientValue.Value))
                    ?? throw new AppException("Option Value is invalid");

                productVarient.VarientValues.Add(new VarientValueEntity()
                {
                    ProductId = product.Id,
                    ProductOptionId = option.Id,
                    ProductOptionValueId = optValue.Id
                });
            }

            _productSkuRepo.Insert(productVarient);

            return Ok(_mapper.Map<ProductVarientDto>(productVarient));
        }

        [HttpPut("{id}/sku/{skuId}")]
        public IActionResult UpdateProductSku(string id, string skuId, [FromBody] CreateUpdateProductVarientDto value)
        {
            return Ok();
        }

        [HttpDelete("varients/{varientId}")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult DeleteProductSku(string varientId)
        {
            var productVarient = _productSkuRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(varientId) && !x.IsDeleted)
                    ?? throw new AppException("Sku is not exist");

            _productSkuRepo.Delete(productVarient);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{id}/varients")]
        public IActionResult GetProductVarients(string id)
        {
            var productVarients = _productSkuRepo
                .GetQueryableNoTracking()
                .Where(x => x.ProductId.Equals(id))
                .ToList();

            return Ok(_mapper.Map<ICollection<ProductVarientDto>>(productVarients));
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

                foreach (var x in value.Options)
                {
                    var productOption = new ProductOptionEntity(x.Title, product.Id);
                    foreach (var optionValue in x.OptionValues)
                        productOption.OptionValues.Add(new ProductOptionValueEntity(optionValue));

                    product.Options.Add(productOption);
                }
                product = _productRepo.Insert(product);

                foreach (var category in value.Categories)
                {
                    product.CategoryProducts.Add(new CategoryProductEntity(
                        category.CategoryId, 
                        product.Id));
                }

                foreach (var inVarient in value.ProductVarients)
                {
                    var productVarient = new ProductVarientEntity(inVarient.Title, inVarient.Price, product.Id);

                    //productVarient.Inventory = new InventoryEntity(productVarient.Id);

                    foreach (var media in inVarient.ProductVarientMedias)
                    {
                        productVarient.VarientMedias.Add(new ProductVarientMediaEntity(
                            media.Url,
                            media.Mime,
                            productVarient.Id));
                    }
                        
                    foreach (var inVarientValue in inVarient.VarientValues)
                    {
                        var option = product
                            .Options
                            .FirstOrDefault(x => x.Title.Equals(inVarientValue.Option))
                                ?? throw new AppException("Option is invalid");

                        var optValue = option
                            .OptionValues
                            .FirstOrDefault(x => x.Value.Equals(inVarientValue.Value))
                                ?? throw new AppException("Option Value is invalid");

                        productVarient.VarientValues.Add(new VarientValueEntity()
                        {
                            ProductId = product.Id,
                            ProductOptionId = option.Id,
                            ProductOptionValueId = optValue.Id
                        });
                    }
                    product.ProductVarients.Add(productVarient);

                }
                _productRepo.SaveChanges();
                _unitOfWork.Complete();
            }
            return Ok(_mapper.Map<AdminProductDto>(product));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult EditProduct(int id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
