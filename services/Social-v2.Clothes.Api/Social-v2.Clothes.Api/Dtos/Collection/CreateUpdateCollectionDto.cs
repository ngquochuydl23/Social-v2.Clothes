using System.ComponentModel.DataAnnotations;

namespace Social_v2.Clothes.Api.Dtos.Collection
{
    public class CreateUpdateCollectionDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Handle { get; set; }
    }
}
