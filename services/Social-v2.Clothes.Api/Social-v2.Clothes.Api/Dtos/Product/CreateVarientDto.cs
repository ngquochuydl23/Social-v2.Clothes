namespace Social_v2.Clothes.Api.Dtos.Product
{
    public class CreateVarientDto
    {
        public string Title { get; set; }

        public double Price { get; set; }

        public List<String> Options { get; set; }  = new List<String>();
    }
}
