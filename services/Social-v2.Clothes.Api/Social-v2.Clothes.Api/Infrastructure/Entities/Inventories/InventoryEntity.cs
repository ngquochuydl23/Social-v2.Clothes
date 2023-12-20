using Social_v2.Clothes.Api.Infrastructure.Entities.Products;
using Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Inventories
{
    public class InventoryEntity : Entity
    {
        public string ProductSkuId { get; set; }

        public virtual ProductVarientEntity ProductSku { get; set; }

        public int Ean { get; set; } = 0;

        public int Upc { get; set; } = 0;

        public int Quantity { get; set; } = 0;

        public bool AllowBackOrder { get; set; } = true;

        public string? StockLocationId { get; set; }

        public ICollection<StockLocationInventoryEntity> StockLocationInventories { get; set; } = new List<StockLocationInventoryEntity>();

        public InventoryEntity(string productSkuId)
        {
            ProductSkuId = productSkuId;
        }
    }
}
