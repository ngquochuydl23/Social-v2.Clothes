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
  [Route("api/admin/[controller]")]
  [ApiController]
  public class ProductController : BaseController
  {
    private readonly IRepository<ProductEntity> _productRepo;
    private readonly IRepository<ProductSkuEntity> _productSkuRepo;
    private readonly IMapper _mapper;

    public ProductController(
        IRepository<ProductEntity> productRepo,
        IRepository<ProductSkuEntity> productSkuRepo,
        IHttpContextAccessor httpContextAccessor,
        IMapper mapper) : base(httpContextAccessor)
    {
      _productRepo = productRepo;
      _productSkuRepo = productSkuRepo;
      _mapper = mapper;
    }


    [AllowAnonymous]
    [HttpGet("admin")]
    public IActionResult GetProducts()
    {

      return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(string id)
    {
      var product = _productRepo
          .GetQueryableNoTracking()
          .FirstOrDefault(x => x.Id.Equals(id))
              ?? throw new AppException("Product is null");

      return Ok(_mapper.Map<AdminProductDto>(product));
    }

    [HttpGet("{id}/sku")]
    public IActionResult GetProductSkuIn(string id, [FromQuery] string productSkuId)
    {
      var product = _productSkuRepo
          .GetQueryableNoTracking()
          .Include(x => x.SkuValues)
          .ThenInclude(skuVal => skuVal.ProductOption)
          .Include(x => x.SkuValues)
          .ThenInclude(skuVal => skuVal.ProductOptionValue)
          .FirstOrDefault(x => x.Id.Equals(productSkuId) && x.ProductId.Equals(id))
              ?? throw new AppException("Sku is null");

      return Ok(_mapper.Map<ProductSkuDto>(product));
    }

    [HttpPost("admin")]
    [Authorize(Roles = "Customer")]
    public IActionResult CreateProduct([FromBody] CreateProductDto value)
    {
      var product = new ProductEntity(
        value.Title,
        value.Subtitle,
        value.Handle,
        value.Description,
        value.Discountable,
        value.Thumbnail);


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



      // create skus
      foreach (var inSku in value.ProductSkus)
      {
        var productSku = new ProductSkuEntity(inSku.Title, inSku.Price, product.Id);

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
    [Authorize(Roles = "Administrator")]
    public IActionResult EditProduct(int id, [FromBody] string value)
    {
      return Ok();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public IActionResult Delete(string id)
    {
      return Ok();
    }
  }
}
