using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Categories
{
  public class CategoryEntity : Entity
  {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    [NotNull]
    public string Id { get; set; }

    [NotNull]
    [MaxLength(CategoryConstants.NameMaxLength)]
    public string Name { get; set; }

    [MaxLength(CategoryConstants.DescriptionMaxLength)]
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    [AllowNull]
    public string? ParentCategoryId { get; set; }

    public virtual CategoryEntity? ParentCategory { get; set; }

    [NotNull]
    [MaxLength(CategoryConstants.HandleMaxLength)]
    public string Handle { get; set; }

    public ICollection<CategoryEntity> ChildCategories { get; set; } = new List<CategoryEntity>();

    public ICollection<CategoryProductEntity> CategoryProducts { get; set; } = new List<CategoryProductEntity>();

    public CategoryEntity(string name, string? description, bool isActive, string? parentCategoryId, string handle)
    {
      Id = GenerateStringId(name);
      Name = name;
      Description = description;
      IsActive = isActive;
      ParentCategoryId = parentCategoryId;
      Handle = handle;
    }
  }
}
