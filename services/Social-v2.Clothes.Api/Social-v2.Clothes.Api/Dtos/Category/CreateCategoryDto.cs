using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Category
{
  public class CreateCategoryDto
  {
    [Required]
    public string Name { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public string? ParentCategoryId { get; set; }

    [Required]
    public string Handle { get; set; }
  }
}
