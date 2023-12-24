namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class CartVarientOptionValueDto
    {
        public string OptionName { get; set; }

        public string OptionValue { get; set; }

        public CartVarientOptionValueDto(string optionName, string optionValue)
        {
            OptionName = optionName;
            OptionValue = optionValue;
        }
    }
}
