using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Social_v2.Clothes.Api.Infrastructure.Entities.Wishlists;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductSkuEntity : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Id { get; set; }

        public string Title { get; set; }

        public string ProductId { get; set; }

        public double Price { get; set; }

        public virtual ProductEntity Product { get; set; }

        public virtual WishlistEntity Wishlist { get; set; }

        public ICollection<SkuValueEntity> SkuValues { get; set; } = new List<SkuValueEntity>();

        public ProductSkuEntity(string title, double price, string productId)
        {
            Id = GenerateProductSkuIdByTitle(title);
            Title = title;
            ProductId = productId;
            Price = price;
        }

        private string GenerateProductSkuIdByTitle(string title)
        {
            string proId = title.ToLower();
            proId = Regex.Replace(proId, "à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ|/g", "a");
            proId = Regex.Replace(proId, "è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ|/g", "e");
            proId = Regex.Replace(proId, "ì|í|ị|ỉ|ĩ|/g", "i");
            proId = Regex.Replace(proId, "ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ|/g", "o");
            proId = Regex.Replace(proId, "ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ|/g", "u");
            proId = Regex.Replace(proId, "ỳ|ý|ỵ|ỷ|ỹ|/g", "y");
            proId = Regex.Replace(proId, "đ", "d");

            return Regex.Replace(proId, @"[^A-Za-z0-9_\.~]+", "-");
        }
    }
}
