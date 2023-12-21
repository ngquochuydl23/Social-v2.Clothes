using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Discounts
{
    public class DiscountConditionEntity : Entity
    {
        public string DiscountCode { get; set; }

        public string Operator { get; set; }

        public ICollection<ProductDiscountConditionEntity> DiscountCondtionProducts { get; set; } = new List<ProductDiscountConditionEntity>();

        public virtual DiscountEntity Discount { get; set; }


        public DiscountConditionEntity() { }

        public DiscountConditionEntity(string discountCode, string operatorDis)
        {
            DiscountCode = discountCode;
            Operator = operatorDis;
        }
    }
}
