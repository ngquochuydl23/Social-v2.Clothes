namespace Social_v2.Clothes.Api.Dtos.Product
{
    public class CreateProductDto
    {
        public string Title { get; set; }
        
        public string Subtitle { get;set; }

        public string Description { get; set; } 

        public bool IsGiftCard { get; set; }

        public bool Discountable { get; set; }

        public string Thumbnail { get; set; }

        public string Handle { get; set; }

        public long Weight { get;set; }

        public long Length {  get; set; }

        public long Width { get; set; }

        public string OriginalCountry { get; set; }

        public string Material { get; set; }

        public string CollectionId { get; set; }

        public List<CreateOptionDto> Options { get; set; } = new List<CreateOptionDto>();

        public List<CreateVarientDto> Varients { get; set; } = new List<CreateVarientDto>();

        public List<ChooseCategoryDto> Categories { get; set; } = new List<ChooseCategoryDto>();
    }
}
