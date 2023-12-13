using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Dtos.Product
{
    public class CreateUpdateProductSkuDto
    {
        public string Title { get; set; }

        public double Price { get; set; }

        public ICollection<CreateProductSkuImageDto> ProSkuMedias { get; set; }

        public ICollection<CreateSkuValueDto> SkuValues { get; set; }

    }
}
