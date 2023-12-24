namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductOptionValueEntity : Entity<long>
    {
        public virtual ProductOptionEntity Option { get; set; }

        public long OptionId { get; set; }

        public string Value { get; set; }

        public List<VarientValueEntity> VarientValues { get; set; } = new List<VarientValueEntity>();

        public ProductOptionValueEntity(string value)
        {
            Value = value;
        }
    }
}
