namespace Social_v2.Clothes.Api.Dtos.Product
{
  public class ProductOptionDto
  {
    public string Title { get; set; }

    public ICollection<ProductOptionValueDto> OptionValues { get; set; } = new List<ProductOptionValueDto>();
  }
}
