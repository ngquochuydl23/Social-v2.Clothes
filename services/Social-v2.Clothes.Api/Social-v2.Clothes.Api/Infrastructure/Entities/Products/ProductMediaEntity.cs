namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductMediaEntity: Entity<long>
    {
        public string Url { get; set; } 

        public long Width { get; set; } 

        public long Height { get; set; }    

        public string Mime { get; set; }

        public string ProductId { get; set; }

        public virtual ProductEntity Product { get; set; }
    }
}
