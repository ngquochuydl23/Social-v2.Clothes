using Clothes.Commons.Seedworks;
using Clothes.User.Api.Infrastucture.Entities.Users;

namespace Clothes.User.Api.Infrastucture.Entities.Wishlists
{
    public class WishlistEntity : Entity<long>
    {

        public long UserId { get; set; }

        public string ProductId { get; set; }
        //ProductId
        public virtual UserEntity User { get; set; }

    }
}
