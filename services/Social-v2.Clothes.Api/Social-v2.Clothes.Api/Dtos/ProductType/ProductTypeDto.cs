using Social_v2.Clothes.Api.Dtos.Category;

namespace Social_v2.Clothes.Api.Dtos.ProductType
{
    public class ProductTypeDto
    {
        public string Id { get; set; }

        public string Name { get; set; }


        public ICollection<CategoryDto> Categories = new List<CategoryDto>();

        public DateTime CreateAt { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
