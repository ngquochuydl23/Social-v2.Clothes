using Clothes.Commons.Seedworks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Clothes.ProductManagement.Api.Infrastructure.Entities.Products;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.Categories
{
    public class CategoryEntity : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [NotNull]
        public string Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        [AllowNull]
        public string? ParentCategoryId { get; set; }

        public virtual CategoryEntity? ParentCategory { get; set; }

        public string Handle { get; set; }


        public ICollection<ProductCategoryEntity> ProductCategories { get; set; } = new List<ProductCategoryEntity>();

        public CategoryEntity(string title, string description, bool isActive)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            IsActive = isActive;
            Handle = GenerateHandleByTitle(title);

        }

        public CategoryEntity(string title, string description, bool isActive, string parentCategoryId) : this(title, description, isActive)
        {
            ParentCategoryId = parentCategoryId;
        }
    }
}
