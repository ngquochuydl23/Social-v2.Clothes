using Microsoft.EntityFrameworkCore;

namespace Clothes.User.Api.Infrastucture
{
    public class ClothesUserContext: DbContext
    {
        public ClothesUserContext(DbContextOptions<ClothesUserContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
