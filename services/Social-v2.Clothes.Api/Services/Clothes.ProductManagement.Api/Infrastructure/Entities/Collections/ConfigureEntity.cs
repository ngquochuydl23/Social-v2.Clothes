using Microsoft.EntityFrameworkCore;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.Collections
{
    public static class ConfigureEntity
    {
        public static void AddCollections(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionEntity>(entity =>
            {
                entity.ToTable("Collection");
                entity.HasKey(x => x.Id);

            });
        }
    }
}
