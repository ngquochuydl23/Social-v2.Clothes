namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductTagEntity: Entity
    {
        public string ProductId { get; set; }

        public string TagId { get; set; }

        public virtual ProductEntity Product { get; set; }

        public virtual TagEntity Tag { get; set; }

        public ProductTagEntity(string productId, string tagId)
        {
            ProductId = productId;
            TagId = tagId;
        }
    }
}
