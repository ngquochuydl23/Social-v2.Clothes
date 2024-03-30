﻿using Clothes.Commons.Seedworks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.Products
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

        public string Status { get; set; }

        public bool IsGiftCard { get; set; }


        public ICollection<ProductCategoryEntity> ProductCategories { get; set; } = new List<ProductCategoryEntity>();

        public ProductEntity(
                string title,
                string subtitle,
                string description,
                bool discountable,
                string thumbnail)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Subtitle = subtitle;
            Handle = GenerateHandleByTitle(title);
            Description = description;
            Discountable = discountable;
            Thumbnail = thumbnail;
        }
    }
}
