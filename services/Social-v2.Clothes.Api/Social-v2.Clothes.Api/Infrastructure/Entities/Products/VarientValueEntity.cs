using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class VarientValueEntity : Entity<long>
    {
        public string ProductId { get; set; }

        public long ProductOptionId { get; set; }

        public long ProductOptionValueId { get; set; }

        public string ProductVarientId { get; set; }

        public virtual ProductEntity Product { get; set; }

        public virtual ProductOptionEntity ProductOption { get; set; }

        public virtual ProductOptionValueEntity ProductOptionValue { get; set; }

        public virtual ProductVarientEntity ProductVarient { get; set; }
    }
}
