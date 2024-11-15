
using BookStore.App.Modules.User;
using BookStore.Data;
using BookStore.App.Services;
using Microsoft.EntityFrameworkCore;
using BookStore.App.Exceptions;

namespace BookStore.App.Modules.Auth
{
 public class AuthRepository(ApplicationDbContext context) : IAuthRepository
 {
  private readonly ApplicationDbContext _context = context;
  public async Task<string> SigIn(AuthViewModel authViewModel)
  {
   try
   {
    UserEntity user = await _context.User.FirstOrDefaultAsync(u => u.Email == authViewModel.Email) ?? throw new NotFound($"nenhum usuário com o e-mail: {authViewModel.Email} encontrado.");

    if (authViewModel.Password == user.Password)
    {
     return TokenService.GenerateJwtToken(user.Id.ToString());
    }
    else
    {
     throw new InvalidCredential("credenciais inválidas");
    }
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }
  }
 }
}
