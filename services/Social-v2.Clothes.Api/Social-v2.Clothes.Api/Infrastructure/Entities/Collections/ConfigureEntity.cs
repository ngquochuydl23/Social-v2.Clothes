using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Collections
{
    public static class ConfigureEntity
    {
        public static void AddCollectionEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollectionEntity>(entity =>
            {
                entity.ToTable("Collection");
                entity.HasKey(x => x.Id);
            });
        }
    }
}
