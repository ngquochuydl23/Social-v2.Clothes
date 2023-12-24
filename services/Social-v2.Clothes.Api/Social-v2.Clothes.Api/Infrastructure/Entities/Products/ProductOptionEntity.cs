namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductOptionEntity : Entity<long>
    {
        public string Title { get; set; }

        public string ProductId { get; set; }

        public virtual ProductEntity Product { get; set; }
         
        public bool IsRoot { get; set; } = false;


        public ICollection<ProductOptionValueEntity> OptionValues { get; set; } = new List<ProductOptionValueEntity>();

        public ICollection<VarientValueEntity> VarientValues { get; set; } = new List<VarientValueEntity>();

        public ProductOptionEntity(string title, string productId)
        {
            Title = title;
            ProductId = productId;
        }
    }
}
