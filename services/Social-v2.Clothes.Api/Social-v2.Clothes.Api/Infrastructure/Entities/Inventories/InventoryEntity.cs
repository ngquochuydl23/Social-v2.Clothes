using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Inventories
{
    public class InventoryEntity : Entity
    {
        public string ProductVarientId { get; set; }

        public virtual ProductVarientEntity ProductVarient { get; set; }

        public long StockedQuantity { get; set; }

        public long ReservedQuantity { get; set; }

        public InventoryEntity(string productVarientId)
        {
            ProductVarientId = productVarientId;
            StockedQuantity = 0;
            ReservedQuantity = 0;
        }
    }
}
