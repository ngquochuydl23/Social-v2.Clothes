using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Dtos.Product;
using Social_v2.Clothes.Api.Infrastructure;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;
using Social_v2.Clothes.Api.Infrastructure.Exceptions;
using Social_v2.Clothes.Api.Infrastructure.Repository;

namespace Social_v2.Clothes.Api.Controllers
{
    [Authorize(Roles = UserConstants.AdministratorRole)]
    [Route("api/admin/Product")]
    [ApiController]
    public class AdminProductController : BaseController
    {
        private readonly IRepository<ProductEntity> _productRepo;
        private readonly IRepository<ProductVarientEntity> _productVarientRepo;
        private readonly IRepository<ProductOptionEntity> _productOptionRepo;
        private readonly IRepository<TagEntity> _tagRepo;
        private readonly IRepository<ProductTagEntity> _productTagRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminProductController(
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
                    ?? throw new AppException("Product does not exist");

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost("{id}/option")]
        public IActionResult AddProductOption(string id, [FromBody] CreateOptionDto pOption)
        {
            var product = _productRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                    ?? throw new AppException("Product does not exist");

            var productOption = _productOptionRepo.Insert(CreateProductOption(pOption, product));
            return Ok(_mapper.Map<ProductOptionDto>(productOption));
        }

        [HttpGet("{id}/varients")]
        public IActionResult GetProductVarients(string id)
        {
            var productVarients = _productVarientRepo
                .GetQueryableNoTracking()
                .Include(x => x.Product)
                .Include(x => x.VarientMedias)
                .Where(x => x.ProductId.Equals(id))
                .ToList();

            return Ok(_mapper.Map<ICollection<ProductVarientDto>>(productVarients));
        }

        [HttpPut("{id}/varients")]
        public IActionResult AddProductVarient(string id, [FromBody] CreateUpdateProductVarientDto proVarient)
        {
            var product = _productRepo
               .GetQueryableNoTracking()
               .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                   ?? throw new AppException("Product does not exist");

            var productVarient = _productVarientRepo.Insert(CreateProductVarient(proVarient, product));

            return Ok(_mapper.Map<ProductVarientDto>(productVarient));
        }

        [HttpDelete("{id}/varients/{varientId}")]
        public IActionResult DeleteProductVarient(string id, string varientId)
        {
            var productVarient = _productVarientRepo
                .GetQueryableNoTracking()
                .FirstOrDefault(x => x.ProductId.Equals(id) && x.Id.Equals(varientId) && !x.IsDeleted)
                    ?? throw new AppException("Varient does not exist");

            _productVarientRepo.Delete(productVarient);
            return Ok();
        }

        [HttpGet("{id}/tags")]
        public IActionResult GetProductTags(string id)
        {
            var productTags = _productTagRepo
                .GetQueryableNoTracking()
                .Include(x => x.Tag)
                .Include(x => x.Product)
                .Where(x => x.ProductId.Equals(id) && !x.Product.IsDeleted)
                .Select(x => x.Tag)
                .ToList();

            return Ok(_mapper.Map<ICollection<TagDto>>(productTags));
        }

        [HttpPost]
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

                foreach (var tag in value.Tags)
                {
                    product.ProductTags.Add(CreateProductTag(tag, product));
                }

                foreach (var category in value.Categories)
                {
                    product.CategoryProducts.Add(CreateCategoryProduct(category, product));
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
        public IActionResult EditGeneralInfo(int id, [FromBody] EditGeneralInfoDto value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var product = _productRepo
               .GetQueryableNoTracking()
               .FirstOrDefault(x => x.Id.Equals(id) && !x.IsDeleted)
                   ?? throw new AppException("Product does not exist");

            _productRepo.Delete(product);
            return Ok();
        }

        private CategoryProductEntity CreateCategoryProduct(ChooseCategoryDto cateInput, ProductEntity product)
        {
            return new CategoryProductEntity(cateInput.CategoryId, product.Id);
        }
        private ProductTagEntity CreateProductTag(string tagName, ProductEntity product)
        {
            var tag = _tagRepo
                .GetQueryableNoTracking()
                .Include(x => x.ProductTags)
                .FirstOrDefault(x => x.TagName.Equals(tagName) && !x.IsDeleted);

            if (tag == null)
            {
                tag = _tagRepo.Insert(new TagEntity(tagName));
            }

            var productTag = new ProductTagEntity(product.Id, tag.Id);

            tag.ProductTags.Add(productTag);
            _tagRepo.SaveChanges();

            return productTag;
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
            ICollection<string> queryOptions = new List<string>();
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

                queryOptions.Add($"{option.Title}={optValue.Value}");
            }

            productVarient.QueryString = "?" + string.Join("&", queryOptions);
            return productVarient;
        }

       
    }
}
