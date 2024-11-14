using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Modules.Auth
{
 [ApiController]
 [Route("api/vi/singin")]
 public class AuthMController(IAuthRepository authRepository) : ControllerBase
 {

  private readonly IAuthRepository _authRepository = authRepository;

  [HttpPost]
  public async Task<ActionResult<string?>> SingIn(AuthViewModel authEntity)
  {
   string? token = await _authRepository.SigIn(authEntity);

   return Ok(token);
  }
 }
}
