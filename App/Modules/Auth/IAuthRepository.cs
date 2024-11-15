namespace BookStore.App.Modules.Auth
{
 public interface IAuthRepository
 {
  Task<string> SigIn(AuthViewModel authViewModel);

  void SigOut(string userId);
 }
}
