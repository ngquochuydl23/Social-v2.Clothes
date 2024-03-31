using Microsoft.EntityFrameworkCore;

namespace Clothes.ProductManagement.Api.Infrastructure
{
    public class ClothesProductContext : DbContext
    {
        public ClothesProductContext(DbContextOptions<ClothesProductContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
