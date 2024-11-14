using BookStore.App.Modules.Admin;
using BookStore.App.Modules.User;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
 public class ApplicationDbContext : DbContext
 {

  public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

  public DbSet<UserEntity> User { get; set; }
  public DbSet<AdminEntity> Admin { get; set; }

 }
}
