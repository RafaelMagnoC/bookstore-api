namespace BookStore.App.Modules.User
{
 public interface IUserRepository
 {
  Task<UserDTO> Add(UserViewModel userViewModel);

  Task<List<UserDTO>> Users();

  Task<UserDTO> User(string userId);

  Task<UserDTO> Att(string userId, UserViewModel userViewModel);

  Task<bool> Remove(string userId);
 }
}
