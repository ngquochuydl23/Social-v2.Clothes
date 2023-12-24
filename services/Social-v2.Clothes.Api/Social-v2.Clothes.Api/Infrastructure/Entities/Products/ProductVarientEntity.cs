using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists;
using System.Diagnostics.CodeAnalysis;
using Social_v2.Clothes.Api.Infrastructure.Entities.Inventories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Cart;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductVarientEntity : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [NotNull]
        public string Id { get; set; }

        public string Title { get; set; }

        public string ProductId { get; set; }

        public double Price { get; set; }

        public virtual ProductEntity Product { get; set; }

        public virtual WishlistEntity Wishlist { get; set; }

        public virtual CartItemEntity CartItem { get; set; }

        public ICollection<ProductVarientMediaEntity> VarientMedias { get; set; } = new List<ProductVarientMediaEntity>();

        public ICollection<VarientValueEntity> VarientValues { get; set; } = new List<VarientValueEntity>();

        public virtual InventoryEntity Inventory { get; set; }

        public ProductVarientEntity(string title, double price, string productId)
        {
            Id = GenerateStringId(title);
            Title = title;
            ProductId = productId;
            Price = price;
        }
    }
}
