namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductVarientMediaEntity : Entity<long>
    {
        public string Url { get; set; }

        public string Mime { get; set; }

        public string ProductVarientId { get; set; }

        public virtual ProductVarientEntity ProductVarient { get; set; }

        public ProductVarientMediaEntity() { }

        public ProductVarientMediaEntity(string url, string mime, string pVarientId)
        {
            Url = url;
            Mime = mime;
            ProductVarientId= pVarientId;
        }
    }
}
