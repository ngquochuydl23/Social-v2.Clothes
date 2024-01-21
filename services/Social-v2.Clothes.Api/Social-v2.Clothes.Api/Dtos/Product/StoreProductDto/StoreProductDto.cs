using Social_v2.Clothes.Api.Dtos.Category;
using Social_v2.Clothes.Api.Dtos.Collection;

namespace Social_v2.Clothes.Api.Dtos.Product.StoreProductDto
{
    public class StoreProductDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Handle { get; set; }

        public bool Discountable { get; set; }

        public string Thumbnail { get; set; }

        public double Price { get; set; }


        public string OtherImage { get; set; }
    }
}
