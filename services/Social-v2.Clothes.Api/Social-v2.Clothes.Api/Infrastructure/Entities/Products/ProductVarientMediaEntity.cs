namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductVarientMediaEntity : Entity<long>
    {
        public string Url { get; set; }

        public string Mime { get; set; }

        public long MediaSetId { get; set; }

        public virtual ProductVarientMediaSetEntity MediaSet { get; set; }


        public ProductVarientMediaEntity(string url, string mime)
        {
            Url = url;
            Mime = mime;
        }
    }
}
