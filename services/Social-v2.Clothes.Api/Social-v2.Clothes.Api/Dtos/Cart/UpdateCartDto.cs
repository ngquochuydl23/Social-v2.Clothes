﻿namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class UpdateCartDto
    {
        public long? CustomerId { get; set; }

        public ICollection<string> GiftCards { get; set; }

    }
}
