using BookStore.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookStore.App.Modules.User
{
 public class UserRepository(ApplicationDbContext context) : IUserRepository
 {
  private readonly ApplicationDbContext _context = context;

  public async Task<UserEntity> Add(UserViewModel userViewModel)
  {

   UserEntity userCreated = new(userViewModel.Name, userViewModel.Email, userViewModel.Password);

   EntityEntry<UserEntity> userAdd = await _context.User.AddAsync(userCreated);
   _context.SaveChanges();

   return userAdd.Entity;
  }

  public Task<UserEntity> Att(string userId, UserViewModel userViewModel)
  {
   throw new NotImplementedException();
  }

  public Task<bool> Remove(string userId)
  {
   throw new NotImplementedException();
  }

  public async Task<UserEntity?> User(string userId)
  {
   return await _context.User.FindAsync(userId);
  }

  public List<UserEntity> Users()
  {
   List<UserEntity> users = [.. _context.User];
   return users;
  }
 }
}
