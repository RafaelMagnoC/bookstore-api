using BookStore.App.Modules.Admin;
using BookStore.App.Modules.User;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
 public class ApplicationDbContext : DbContext
 {

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

  public required DbSet<UserEntity> User { get; set; }
  public required DbSet<AdminEntity> Admin { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
   base.OnModelCreating(modelBuilder);

   modelBuilder.Entity<AdminEntity>()
    .HasOne(admin => admin.User)
    .WithOne(user => user.Admin)
    .HasForeignKey<UserEntity>(user => user.AdminId)
    .OnDelete(DeleteBehavior.Cascade);
  }
 }
}
