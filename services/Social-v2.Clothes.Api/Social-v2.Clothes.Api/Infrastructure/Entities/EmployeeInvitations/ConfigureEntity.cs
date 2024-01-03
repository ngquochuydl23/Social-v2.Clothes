using Microsoft.EntityFrameworkCore;
using Social_v2.Clothes.Api.Infrastructure.Entities.Categories;
using Social_v2.Clothes.Api.Infrastructure.Entities.EmployeeInvitations;
using Social_v2.Clothes.Api.Infrastructure.Entities.Users;

namespace Social_v2.Clothes.Api.Infrastructure.Entities.Invites
{
    public static class ConfigureEntity
    {
        public static void AddEmployeeInvitationEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeInvitationEntity>(entity =>
            {
                entity.ToTable("EmployeeInvitation");
                entity.HasKey(x => x.Id);


                entity
                    .HasOne(x => x.Employee)
                    .WithOne(employee => employee.EmployeeInvitation)
                    .HasForeignKey<EmployeeInvitationEntity>(x => x.EmployeeId);
            });
        }
    }
}
