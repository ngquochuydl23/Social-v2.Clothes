namespace Social_v2.Clothes.Api.Dtos.Category
{
  public class CategoryDto
  {
    public string Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public CategoryDto ParentCategory { get; set; }

    public ICollection<CategoryDto> ChildCategories { get; set; }

    public string Handle { get; set; }

    public bool IsActive { get; set; }
  }
}
