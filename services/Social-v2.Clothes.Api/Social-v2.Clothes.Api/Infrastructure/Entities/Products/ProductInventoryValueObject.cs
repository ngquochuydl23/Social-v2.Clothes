namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductInventoryValueObject
    {
        public string SKU { get; set; }

        public string Barcode { get; set; }

        public bool AutoManageInventory { get; set; }

        public bool AllowBackOrders { get; set; }
    }
}
