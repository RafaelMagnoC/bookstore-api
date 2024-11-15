using BookStore.App.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.App.Modules.Admin
{
 [ApiController]
 [Route("api/v1/admin")]
 public class AdminController(IAdminRepository adminRepository) : ControllerBase
 {
  private readonly IAdminRepository _adminRepository = adminRepository;

  [HttpPost]
  public async Task<ActionResult<AdminDTO>> Add(AdminViewModel adminViewModel)
  {
   try
   {
    AdminDTO admin = await _adminRepository.AdminAdd(adminViewModel);

    return Ok(admin);
   }
   catch (CreateException exception)
   {
    throw new CreateException(exception.ToString());
   }
   catch (BadRequest exception)
   {
    throw new BadRequest(exception.ToString());
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }
  }

  [HttpGet("{adminId}")]
  public async Task<ActionResult<AdminDTO>> Admin([FromRoute] string adminId)
  {
   try
   {
    AdminDTO admin = await _adminRepository.Admin(adminId);

    return Ok(admin);
   }
   catch (NotFound exception)
   {
    throw new NotFound(exception.ToString());
   }
   catch (BadRequest exception)
   {
    throw new BadRequest(exception.ToString());
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }
  }

  [HttpGet]
  public async Task<ActionResult<List<AdminDTO>>> Admins()
  {
   try
   {
    List<AdminDTO> admins = await _adminRepository.Admins();

    return Ok(admins);
   }
   catch (Exception exceptioin)
   {
    throw new Exception(exceptioin.ToString());
   }
  }

  [HttpPatch("{adminId}")]
  public async Task<ActionResult<AdminDTO>> AdminAt([FromRoute] string adminId, AdminViewModel adminViewModel)
  {
   try
   {
    AdminDTO admin = await _adminRepository.AdminAt(adminId, adminViewModel);

    return Ok(admin);
   }
   catch (NotFound exception)
   {
    throw new NotFound(exception.ToString());
   }
   catch (BadRequest exception)
   {
    throw new BadRequest(exception.ToString());
   }
   catch (UpdateException exception)
   {
    throw new UpdateException(exception.ToString());
   }
   catch (Exception exceptioin)
   {
    throw new Exception(exceptioin.ToString());
   }
  }

  [HttpDelete("{adminId}")]
  public async Task<ActionResult<bool>> Delete([FromRoute] string adminId)
  {
   try
   {
    bool adminRemoved = await _adminRepository.AdminRemove(adminId);

    return Ok(adminRemoved);
   }
   catch (NotFound exception)
   {
    throw new NotFound(exception.ToString());
   }
   catch (BadRequest exception)
   {
    throw new BadRequest(exception.ToString());
   }
   catch (RemoveException exception)
   {
    throw new RemoveException(exception.ToString());
   }
   catch (Exception exceptioin)
   {
    throw new Exception(exceptioin.ToString());
   }
  }
 }
}
