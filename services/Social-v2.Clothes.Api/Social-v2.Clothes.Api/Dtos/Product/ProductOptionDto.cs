namespace Social_v2.Clothes.Api.Dtos.Product
{
    public class ProductOptionDto
    {

        public long Id { get; set; }

        public string Title { get; set; }

        public ICollection<ProductOptionValueDto> OptionValues { get; set; } = new List<ProductOptionValueDto>();
    }
}
