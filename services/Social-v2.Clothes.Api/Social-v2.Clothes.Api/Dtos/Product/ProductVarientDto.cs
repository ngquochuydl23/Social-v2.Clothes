﻿using Newtonsoft.Json;
using Social_v2.Clothes.Api.Infrastructure.Entities.Products;

namespace Social_v2.Clothes.Api.Dtos.Product
{
    public class ProductVarientDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string ProductId { get; set; }

        public double Price { get; set; }

        public string Thumbnail { get; set; }

        public string ProductTitle { get; set; }

        public ICollection<ProductVarientMediaDto> VarientMedias { get; set; } = new List<ProductVarientMediaDto>();
    }
}
