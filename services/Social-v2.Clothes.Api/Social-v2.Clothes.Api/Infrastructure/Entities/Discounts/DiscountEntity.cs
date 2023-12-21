using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Discounts
{
    public class DiscountEntity : Entity
    {

        public string Code { get; set; }

        public DateTime StartsAt { get; set; }

        public DateTime EndsAt { get; set; }

        public bool IsDisabled { get; set; }

        public int UsageLimit { get; set; } = 0;

        [NotNull]
        [MaxLength(DiscountConstants.RuleTypeMaxLength)]
        public string RuleType { get; set; }

        [NotNull]
        [MaxLength(DiscountConstants.RuleAllocationMaxLength)]
        public string RuleAllocation { get; set; }

        public int RuleValue { get; set; }

        [MaxLength(DiscountConstants.RuleDescriptionMaxLength)]
        public string? RuleDescription { get; set; }

        public virtual DiscountConditionEntity Condition { get; set; }

        public DiscountEntity(
            string code,
            DateTime startsAt,
            DateTime endsAt,
            bool isDisabled,
            int usageLimit,
            string ruleType,
            string ruleAllocation,
            int ruleValue,
            string? ruleDescription)
        {
            Code = code;
            StartsAt = startsAt;
            EndsAt = endsAt;
            IsDisabled = isDisabled;
            UsageLimit = usageLimit;
            RuleType = ruleType;
            RuleAllocation = ruleAllocation;
            RuleValue = ruleValue;
            RuleDescription = ruleDescription;
        }

        
    }
}
