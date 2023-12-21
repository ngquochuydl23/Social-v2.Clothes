using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Dtos.Product
{
  public class AdminProductDto
  {
    public string Id { get; set; }

    public string Title { get; set; }

    public string Subtitle { get; set; }

    public string Handle { get; set; }

    public string Description { get; set; }

    public bool Discountable { get; set; }

    public string Thumbnail { get; set; }

    public ProductVarientDto ProductSku { get; set; }

    public ICollection<ProductOptionDto> Options { get; set; } = new List<ProductOptionDto>();
  }
}
