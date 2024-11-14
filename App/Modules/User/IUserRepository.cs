namespace BookStore.App.Modules.User
{
 public interface IUserRepository
 {
  Task<UserEntity> Add(UserViewModel userViewModel);

  List<UserEntity> Users();

  Task<UserEntity?> User(string userId);

  Task<UserEntity> Att(string userId, UserViewModel userViewModel);

  Task<bool> Remove(string userId);
 }
}
