using Social_v2.Clothes.Api.Infrastructure.Entities;

namespace Social_v2.Clothes.Api.Dtos.Product
{
    public class CreateProductSkuImageDto
    {
        public string Url { get; set; }

        public string Mime { get; set; }

        public long Width { get; set; }

        public long Height { get; set; }
    }
}
