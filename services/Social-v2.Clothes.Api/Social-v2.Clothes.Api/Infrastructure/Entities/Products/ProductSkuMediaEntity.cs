namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductSkuMediaEntity : Entity<long>
    {
        public string Url { get; set; }

        public long Width { get; set; }

        public long Height { get; set; }

        public string Mime { get; set; }

        public string ProductSkuId { get; set; }

        public virtual ProductSkuEntity ProductSku { get; set; }

        public ProductSkuMediaEntity(string url, long width, long height, string mime, string productSkuId)
        {
            Url = url;
            Width = width;
            Height = height;
            Mime = mime;
            ProductSkuId = productSkuId;
        }
    }
}
