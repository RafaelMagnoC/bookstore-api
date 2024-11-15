
using BookStore.App.Modules.User;
using BookStore.Data;
using BookStore.App.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.App.Modules.Auth
{
 public class AuthRepository(ApplicationDbContext context) : IAuthRepository
 {
  private readonly ApplicationDbContext _context = context;
  public async Task<string?> SigIn(AuthViewModel authViewModel)
  {

   UserEntity? user = await _context.User.FirstOrDefaultAsync(u => u.Email == authViewModel.Email);

   if (user != null && authViewModel.Password == user.Password)
   {
    string auth = TokenService.GenerateJwtToken(user.Id.ToString());
    return auth;
   }

   return null;
  }
 }
}
