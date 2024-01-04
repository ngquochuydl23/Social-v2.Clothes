using Social_v2.Clothes.Api.Dtos.Product;

namespace Social_v2.Clothes.Api.Dtos.Inventory
{
    public class InventoryDto
    {
        public long StockedQuantity { get; set; }

        public long ReservedQuantity { get; set; }

        public ProductVarientInventoryDto ProductVarient { get; set; }
        
    }
}
