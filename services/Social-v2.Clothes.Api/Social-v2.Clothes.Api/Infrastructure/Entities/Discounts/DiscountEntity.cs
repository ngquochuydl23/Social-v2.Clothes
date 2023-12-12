namespace Social_v2.Clothes.Api.Infrastructure.Entities.Discounts
{
    public class DiscountEntity : Entity
    {
        public string Code { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        public bool IsDisabled { get; set; }

        public int UsageLimit { get; set; } = 0;
    }
}
