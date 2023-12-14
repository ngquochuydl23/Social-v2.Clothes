namespace Social_v2.Clothes.Api.Dtos
{
    public class CreateDiscountDto
    {
        public string Code { get; set; }

        public DateTime StartsAt { get; set; }

        public DateTime EndsAt { get; set; }

        public int UsageLimit { get; set; }

        public bool IsDisabled { get; set; } = false;

        public string RuleType { get; set; }
            
        public int RuleValue { get; set; }

        public string RuleAllocation { get; set; }  

        public string? RuleDescription { get; set; }
    }
}
