using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Inventories
{
    public class InventoryEntity : Entity
    {
        public string ProductSkuId { get; set; }

        public virtual ProductSkuEntity ProductSku { get; set; }

        public int Ean { get; set; } = 0;

        public int Upc { get; set; } = 0;

        public int Quantity { get; set; } = 0;

        public bool AllowBackOrder { get; set; } = true;

        public string? StockLocationId { get; set; }

        public InventoryEntity(string productSkuId)
        {
            ProductSkuId = productSkuId;
        }
    }
}
