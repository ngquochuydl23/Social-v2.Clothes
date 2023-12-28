﻿namespace Social_v2.Clothes.Api.Dtos.Users
{
    public class UserDto
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int Gender { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime LastUpdate { get; set; }

        public DateTime Birthday { get; set; }

        public string Role { get; set; }

        public string Avatar { get; set; }
    }
}
