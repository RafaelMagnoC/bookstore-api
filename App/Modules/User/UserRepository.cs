using AutoMapper;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookStore.App.Modules.User
{
 public class UserRepository(ApplicationDbContext context, IMapper mapper) : IUserRepository
 {
  private readonly ApplicationDbContext _context = context;
  private readonly IMapper _mapper = mapper;

  public async Task<UserDTO?> Add(UserViewModel userViewModel)
  {
   try
   {

    UserEntity userEntity = new(userViewModel.Name, userViewModel.Email, userViewModel.Password);

    EntityEntry<UserEntity> user = await _context.User.AddAsync(userEntity);
    await _context.SaveChangesAsync();

    UserDTO? userExists = await this.User(userEntity.Id.ToString());

    return userExists;

   }
   catch (Exception ex)
   {
    throw new Exception(ex.ToString());
   }
  }

  public async Task<UserDTO?> Att(string userId, UserViewModel userViewModel)
  {
   try
   {
    UserEntity? userExists = await _context.User.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

    if (userExists == null)
    {
     return null;
    }

    userExists.Name = userViewModel.Name;
    userExists.Email = userViewModel.Email;
    userExists.Password = userViewModel.Password;
    userExists.UpdatedAt = DateTime.Now;

    _context.User.Update(userExists);

    await _context.SaveChangesAsync();

    return await User(userExists.Id.ToString());
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }

  }

  public async Task<bool?> Remove(string userId)
  {
   try
   {
    UserEntity? userExists = await _context.User.FirstOrDefaultAsync(u => u.Id.ToString() == userId);

    if (userExists == null)
    {
     return null;
    }

    _context.User.Remove(userExists);

    int userSuccessfullyRemoved = await _context.SaveChangesAsync();

    return userSuccessfullyRemoved == 1;
   }
   catch (Exception ex)
   {
    throw new Exception(ex.ToString());
   }

  }

  public async Task<UserDTO?> User(string userId)
  {
   UserEntity? user = await _context.User.FindAsync(userId);

   if (user == null)
   {
    return null;
   }

   return _mapper.Map<UserDTO>(user);
  }

  public async Task<List<UserDTO>> Users()
  {
   List<UserEntity> users = await _context.User.ToListAsync();
   return users.Count > 0 ? _mapper.Map<List<UserDTO>>(users) : [];
  }
 }
}
