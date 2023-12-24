using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Dtos.Product
{
    public class CreateUpdateProductVarientDto
    {
        public string Title { get; set; }

        public double Price { get; set; }

        public ICollection<CreateProductOptionMediaDto> ProductVarientMedias { get; set; }

        public ICollection<CreateVarientValueDto> VarientValues { get; set; }
    }
}
