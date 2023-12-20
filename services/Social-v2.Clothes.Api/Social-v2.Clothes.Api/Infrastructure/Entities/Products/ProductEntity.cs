using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Collections;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Products
{
    public class ProductEntity : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Handle { get; set; }

        public string Description { get; set; }

        public bool Discountable { get; set; }

        public string Thumbnail { get; set; }

        public virtual ICollection<ProductOptionEntity> Options { get; set; } = new List<ProductOptionEntity>();

        public virtual ICollection<ProductVarientEntity> ProductVarients { get; set; } = new List<ProductVarientEntity>();

        public ICollection<CategoryProductEntity> CategoryProducts { get; set; } = new List<CategoryProductEntity>();

        public virtual ICollection<VarientValueEntity> VarientValues { get; set; } = new List<VarientValueEntity>();

        public string? CollectionId { get; set; }

        public virtual CollectionEntity? Collection { get; set; }

        public ProductEntity(
                string title,
                string subtitle,
                string handle,
                string description,
                bool discountable,
                string thumbnail,
                string collectionId)
        {
            Id = GenerateProductIdByTitle(title);
            Title = title;
            Subtitle = subtitle;
            Handle = handle;
            Description = description;
            Discountable = discountable;
            Thumbnail = thumbnail;
            CollectionId = collectionId;
        }

        private string GenerateProductIdByTitle(string title)
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

        public ProductEntity AddVarient()
        {
            return this;
        }
    }
}
