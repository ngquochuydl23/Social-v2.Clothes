using Clothes.ProductManagement.Api.Infrastructure.Entities.ProductTags;
using Microsoft.EntityFrameworkCore;

namespace Clothes.ProductManagement.Api.Infrastructure.Entities.Tags
{
    public static class ConfigureEntity
    {
        public static void AddTags(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TagEntity>(entity =>
            {
                entity.ToTable("Tag");
                entity.HasKey(x => x.Id);

            });
        }
    }
}
