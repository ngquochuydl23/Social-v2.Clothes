﻿namespace Social_v2.Clothes.Api.Dtos.Cart
{
    public class CartDto
    {
        public long Id { get; set; } 

        public CartCustomerDto? Customer { get; set; }
    }
}
