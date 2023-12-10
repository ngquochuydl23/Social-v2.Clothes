using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Dtos.Product
{
  public class ProductSkuDto
  {
    public string Id { get; set; }

    public string Title { get; set; }

    public string ProductId { get; set; }

    public double Price { get; set; }

    public ICollection<SkuValueEntity> SkuValues { get; set; } = new List<SkuValueEntity>();
  }
}
