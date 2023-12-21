namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductVarientMediaSetEntity : Entity<long>
    {
        public long RootProductOptionId { get; set; }

        public long RootOptionValueId { get; set; }

        public virtual ProductOptionEntity RootProductOption { get; set; }

        public virtual ProductOptionValueEntity RootOptionValue { get; set; }


        public ICollection<ProductVarientEntity> ProductVarients = new List<ProductVarientEntity>();


        public ICollection<ProductVarientMediaEntity> ProductMedias = new List<ProductVarientMediaEntity>();

        public ProductVarientMediaSetEntity(long rootProductOptionId)
        {
            RootProductOptionId = rootProductOptionId;
        }
    }
}
