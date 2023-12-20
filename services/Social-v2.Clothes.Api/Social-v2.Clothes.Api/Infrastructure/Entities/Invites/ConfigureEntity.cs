using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Invites
{
    public static class ConfigureEntity
    {
        public static void AddInviteEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InviteEntity>(entity =>
            {
                entity.ToTable("Invite");
                entity.HasKey(x => x.Id);
            });
        }
    }
}
