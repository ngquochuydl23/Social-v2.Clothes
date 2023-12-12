using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Category
{
  public class AddProductToCategoryDto
  {
    [Required]
    public string ProductId { get; set; }
  }
}
