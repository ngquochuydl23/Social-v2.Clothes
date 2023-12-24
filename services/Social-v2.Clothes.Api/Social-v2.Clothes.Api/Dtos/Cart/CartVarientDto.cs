using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class CartVarientDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ProductId { get; set; }

        public double Price { get; set; }

        public string FirstVarientImageUrl { get; set; }

        public ICollection<CartVarientOptionValueDto> VarientOptionValues { get; set; } = new List<CartVarientOptionValueDto>();

        public CartVarientDto(ProductVarientEntity entity)
        {

            Id = entity.Id;
            Title = entity.Title;
            ProductId = entity.ProductId;
            Price = entity.Price;

            FirstVarientImageUrl = entity.VarientMedias.First().Url;

            foreach (var varientValue in entity.VarientValues)
            {
                var productOption = varientValue.ProductOption.Title;
                var productOptionValue = varientValue.ProductOptionValue.Value;

                VarientOptionValues.Add(new CartVarientOptionValueDto(productOption, productOptionValue));
            }
        }
    }
}
