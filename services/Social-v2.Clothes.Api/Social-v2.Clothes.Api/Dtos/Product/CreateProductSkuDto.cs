using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Dtos.Product
{
  public class CreateProductSkuDto
  {
    public string Title { get; set; }

    public double Price { get; set; }


    public ICollection<CreateSkuValueDto> SkuValues { get; set; }

  }
}
