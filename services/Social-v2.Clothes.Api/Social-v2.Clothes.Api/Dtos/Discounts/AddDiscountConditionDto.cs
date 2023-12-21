namespace Social_v2.Clothes.Api.Dtos.Discounts
{
    public class AddDiscountConditionDto
    {
        public string Operator { get; set; }

        public ICollection<string> AppliedProducts { get; set; } = new List<string>();
    }
}
