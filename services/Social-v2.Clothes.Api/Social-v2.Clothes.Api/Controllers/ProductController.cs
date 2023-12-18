using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Product;
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
        private readonly IRepository<ProductSkuEntity> _productSkuRepo;
        private readonly IRepository<ProductOptionEntity> _productOptionRepo;
        private readonly IMapper _mapper;

        public ProductController(
            IRepository<ProductEntity> productRepo,
            IRepository<ProductSkuEntity> productSkuRepo,
            IRepository<ProductOptionEntity> productOptionRepo,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper) : base(httpContextAccessor)
        {
            _productRepo = productRepo;
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
      //  [Authorize(Roles = UserConstants.AdministratorRole)]
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
        [HttpGet("sku/{skuId}")]
        public IActionResult GetProductSku(string skuId)
        {
            var product = _productSkuRepo
                .GetQueryableNoTracking()
                .Include(x => x.SkuValues)
                .ThenInclude(skuVal => skuVal.ProductOption)
                .Include(x => x.SkuValues)
                .ThenInclude(skuVal => skuVal.ProductOptionValue)
                .FirstOrDefault(x => x.Id.Equals(skuId))
                    ?? throw new AppException("Sku is null");

            return Ok(_mapper.Map<ProductSkuDto>(product));
        }


        [AllowAnonymous]
        [HttpGet("sku/{skuId}/inventory")]
        public IActionResult GetProductSkuInInventory(string skuId)
        {
            return Ok();
        }

        [HttpPut("{id}/sku")]
        public IActionResult CreateProductSku(string id, [FromBody] CreateUpdateProductSkuDto value)
        {
            var product = _productRepo
               .GetQueryableNoTracking()
               .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                   ?? throw new AppException("Product is null");

            var productSku = new ProductSkuEntity(value.Title, value.Price, product.Id);

            // add inventory in relation to sku
            productSku.Inventory = new InventoryEntity(productSku.Id);

            // add medias to each sku
            foreach (var media in value.ProSkuMedias)
                productSku.ProductMedias.Add(
                    new ProductSkuMediaEntity(media.Url, media.Width, media.Height, media.Mime, productSku.Id));

            // add sku value to each sku
            foreach (var inSkuValue in value.SkuValues)
            {
                var option = product.Options.FirstOrDefault(x => x.Title.Equals(inSkuValue.Option))
                    ?? throw new AppException("Option is invalid");

                var optValue = option.OptionValues.FirstOrDefault(x => x.Value.Equals(inSkuValue.Value))
                    ?? throw new AppException("Option Value is invalid");

                productSku.SkuValues.Add(new SkuValueEntity()
                {
                    ProductId = product.Id,
                    ProductOptionId = option.Id,
                    ProductOptionValueId = optValue.Id
                });
            }

            _productSkuRepo.Insert(productSku);

            return Ok(_mapper.Map<ProductSkuDto>(productSku));
        }

        [HttpPut("{id}/sku/{skuId}")]
        public IActionResult UpdateProductSku(string id, string skuId, [FromBody] CreateUpdateProductSkuDto value)
        {
            return Ok();
        }

        [HttpDelete("sku/{skuId}")]
        [Authorize(Roles = UserConstants.AdministratorRole)]
        public IActionResult DeleteProductSku(string skuId)
        {
            var productSku = _productSkuRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(skuId) && !x.IsDeleted)
                    ?? throw new AppException("Sku is not exist");

            _productSkuRepo.Delete(productSku);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet("{id}/skus")]
        public IActionResult GetProductSkus(string id)
        {
            var productSkus = _productSkuRepo
                .GetQueryableNoTracking()
                .Where(x => x.ProductId.Equals(id))
                .ToList();

            return Ok(_mapper.Map<ICollection<ProductSkuDto>>(productSkus));
        }

        [HttpPost]
       // [Authorize(Roles = UserConstants.AdministratorRole)]
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

            if (_productRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(product.Id)) != null)
                throw new Exception("Product is already exist.");

            // creating options and option values
            foreach (var x in value.Options)
            {
                var productOption = new ProductOptionEntity(x.Title, product.Id);
                foreach (var optionValue in x.OptionValues)
                    productOption.OptionValues.Add(new ProductOptionValueEntity(optionValue));

                product.Options.Add(productOption);
            }
            product = _productRepo.Insert(product);

            // add to category

            foreach (var category in value.Categories)
            {
                var categoryProduct = new CategoryProductEntity(category.CategoryId, product.Id);
                product.CategoryProducts.Add(categoryProduct);
            }

            // create skus
            foreach (var inSku in value.ProductSkus)
            {
                var productSku = new ProductSkuEntity(inSku.Title, inSku.Price, product.Id);

                // add inventory in relation to sku
                productSku.Inventory = new InventoryEntity(productSku.Id);

                // add medias to each sku
                foreach (var media in inSku.ProSkuMedias)
                    productSku.ProductMedias.Add(
                        new ProductSkuMediaEntity(media.Url, media.Width, media.Height, media.Mime, productSku.Id));

                // add sku value to each sku
                foreach (var inSkuValue in inSku.SkuValues)
                {
                    var option = product.Options.FirstOrDefault(x => x.Title.Equals(inSkuValue.Option))
                        ?? throw new AppException("Option is invalid");

                    var optValue = option.OptionValues.FirstOrDefault(x => x.Value.Equals(inSkuValue.Value))
                        ?? throw new AppException("Option Value is invalid");

                    productSku.SkuValues.Add(new SkuValueEntity()
                    {
                        ProductId = product.Id,
                        ProductOptionId = option.Id,
                        ProductOptionValueId = optValue.Id
                    });
                }
                product.ProductSkus.Add(productSku);
            }

            _productRepo.SaveChanges();

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
