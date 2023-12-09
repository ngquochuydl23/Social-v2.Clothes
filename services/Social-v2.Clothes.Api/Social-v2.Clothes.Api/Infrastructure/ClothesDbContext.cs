
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Social_v2.Clothes.Api.Infrastructure
{
  public class ClothesDbContext : DbContext
  {
    public ClothesDbContext(DbContextOptions<ClothesDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.Entity<CourseEntity>(entity =>
      //{
      //  entity.ToTable("Course");
      //  entity.HasKey(x => x.Id);
      //});

      //modelBuilder.Entity<StudentEntity>(entity =>
      //{
      //  entity.ToTable("Student");
      //  entity.HasKey(x => x.Id);
      //});

      //modelBuilder.Entity<SubjectEntity>(entity =>
      //{
      //  entity.ToTable("Subject");
      //  entity.HasKey(x => x.Id);
      //});

      //modelBuilder.Entity<PreSubjectEntity>(entity =>
      //{
      //  entity.ToTable("PreSubject");
      //  entity.HasKey(x => x.Id);

      //  entity
      //    .HasOne(pre => pre.PreSubject)
      //    .WithMany(sub => sub.PreSubjects)
      //    .HasForeignKey(pre => pre.PreSubjectId);

      //  entity
      //    .HasOne(current => current.CurrentSubject)
      //    .WithMany(sub => sub.PreSubjects)
      //    .HasForeignKey(pre => pre.PreSubjectId);
      //});

      //modelBuilder.Entity<PlaylistSongEntity>(entity =>
      //{
      //  entity.ToTable("PlaylistSong");
      //  entity.HasKey(x => x.Id);
      //  entity
      //    .HasOne(x => x.Playlist)
      //    .WithMany(playlist => playlist.PlaylistSongs)
      //    .HasForeignKey(x => x.PlaylistId);
      //});

      //modelBuilder.Entity<CollaboratorEntity>(entity =>
      //{
      //  entity.ToTable("Collaborator");
      //  entity.HasKey(x => x.Id);
      //  entity
      //    .HasOne(x => x.Playlist)
      //    .WithMany(playlist => playlist.Collaborators)
      //    .HasForeignKey(x => x.PlaylistId);
      //});
    }
  }
}
