using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Feedbacks
{
    public class FeecbackEntity : Entity<long>
    {
        public virtual UserEntity Customer { get; set; }

        public long CustomerId { get; set; }

        public string FeedbackContent { get; set; }

        public double Rating { get; set; }

        public ProductVarientEntity ProductVarient { get; set; }

        public string ProductVarientId { get; set; }

        public ProductEntity Product { get; set; }

        public string ProductId { get; set; }
    }
}
