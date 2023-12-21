using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Discounts
{
    public class ProductDiscountConditionEntity: Entity<long>
    {
        public string DiscountConditionId { get; set; }

        public string ProductId { get; set; }

        public virtual DiscountConditionEntity DiscountCondition { get; set; }

        public virtual ProductEntity Product { get; set; }

        public ProductDiscountConditionEntity(string discountConditionId, string productId)
        {
            DiscountConditionId = discountConditionId;
            ProductId = productId;
            CreateAt= DateTime.Now;
        }
    }
}
