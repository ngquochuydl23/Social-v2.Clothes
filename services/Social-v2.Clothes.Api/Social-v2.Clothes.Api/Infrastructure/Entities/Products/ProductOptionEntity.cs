namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
  public class ProductOptionEntity : Entity<long>
  {
    public string Title { get; set; }

    public string ProductId { get; set; }

    public virtual ProductEntity Product { get; set; }

    public ICollection<ProductOptionValueEntity> OptionValues { get; set; } = new List<ProductOptionValueEntity>();

    public ICollection<SkuValueEntity> SkuValues { get; set; } = new List<SkuValueEntity>();

    public ProductOptionEntity(string title, string productId)
    {
      Title = title;
      ProductId = productId;
    }
  }
}
