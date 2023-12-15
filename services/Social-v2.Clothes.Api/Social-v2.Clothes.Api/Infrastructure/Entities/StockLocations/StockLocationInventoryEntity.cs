using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Stores;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.StockLocations
{
    public class StockLocationInventoryEntity: Entity
    {
        public string StockLocationId { get; set; }

        public string ProductSkuId { get; set; }

        public virtual StockLocationEntity StockLocation { get; set; }

        public virtual InventoryEntity Inventory { get; set; }
    }
}
