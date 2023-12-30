namespace Social_v2.Clothes.Api.Dtos.Customer
{
    public class CustomerDto
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public DateTime CreateAt { get; set; }

        public long OrdersCount { get; set; }
    }
}
