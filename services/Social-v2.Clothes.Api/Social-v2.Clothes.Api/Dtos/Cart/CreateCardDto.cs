using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class CreateCardDto
    {
        [Required]
        public string RegionId { get; set; }

        [Required]
        public ICollection<CreateCartItemDto> Items { get; set; } = new List<CreateCartItemDto>();
    }
}
