using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Modules.User
{
 [ApiController]
 [Route("api/v1/user")]
 public class UserController(IUserRepository userRepository) : ControllerBase
 {
  private readonly IUserRepository _userRepository = userRepository;

  [HttpPost]
  public async Task<ActionResult<UserEntity>> Add(UserViewModel userViewModel)
  {
   UserEntity user = await _userRepository.Add(userViewModel);

   return user;
  }

  [HttpGet]
  public ActionResult<List<UserEntity>> Users()
  {
   List<UserEntity> users = _userRepository.Users();

   return users;
  }

  [HttpGet("{userId}")]
  public async Task<ActionResult<UserEntity?>> UserId([FromRoute] string userId)
  {
   return await _userRepository.User(userId);
  }
 }
}
