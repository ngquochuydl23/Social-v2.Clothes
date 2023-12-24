namespace Social_v2.Clothes.Api.Dtos.Product
{
    public class CreateOptionDto
    {
        public string Title { get; set; }

        public List<string> OptionValues { get; set; } = new List<string>();
    }
}
