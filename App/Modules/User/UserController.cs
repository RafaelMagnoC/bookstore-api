using BookStore.App.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Modules.User
{
 [ApiController]
 [Route("api/v1/user")]
 public class UserController(IUserRepository userRepository) : ControllerBase
 {
  private readonly IUserRepository _userRepository = userRepository;

  [HttpPost]
  public async Task<ActionResult<UserDTO?>> Add(UserViewModel userViewModel)
  {
   UserDTO? user = await _userRepository.Add(userViewModel);

   return user;
  }

  [HttpGet]
  public async Task<ActionResult<List<UserDTO>>> Users()
  {
   List<UserDTO> users = await _userRepository.Users();
   return users;
  }

  [HttpGet("{userId}")]
  public async Task<ActionResult<UserDTO?>> UserId([FromRoute] string userId)
  {
   return await _userRepository.User(userId);
  }

  [HttpPatch("{userId}")]
  public async Task<ActionResult<UserDTO?>> Att([FromRoute] string userId, UserViewModel userViewModel)
  {
   return await _userRepository.Att(userId, userViewModel);
  }

  [HttpDelete("{userId}")]
  public async Task<ActionResult<bool>> Remove([FromRoute] string userId)
  {
   return await _userRepository.Remove(userId);
  }
 }
}
