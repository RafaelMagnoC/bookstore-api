using AutoMapper;
using BookStore.App.Exceptions;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookStore.App.Modules.User
{
 public class UserRepository(ApplicationDbContext context, IMapper mapper) : IUserRepository
 {
  private readonly ApplicationDbContext _context = context;
  private readonly IMapper _mapper = mapper;

  public async Task<UserDTO> Add(UserViewModel userViewModel)
  {
   try
   {

    UserEntity userEntity = new(userViewModel.Name, userViewModel.Email, userViewModel.Password);

    EntityEntry<UserEntity> user = await _context.User.AddAsync(userEntity);
    int userCreated = await _context.SaveChangesAsync();

    return userCreated > 0 ? _mapper.Map<UserDTO>(user.Entity) : throw new CreateException("um erro ocorreu ao cadastrar o usuário");
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }
  }

  public async Task<UserDTO> Att(string userId, UserViewModel userViewModel)
  {
   try
   {
    UserEntity userExists = await _context.User.FirstOrDefaultAsync(u => u.Id.ToString() == userId) ?? throw new NotFound($"nenhum usuário com o id: {userId} encontrado.");
    userExists.Name = userViewModel.Name;
    userExists.Email = userViewModel.Email;
    userExists.Password = userViewModel.Password;
    userExists.UpdatedAt = DateTime.Now;

    _context.User.Update(userExists);

    int userUpdated = await _context.SaveChangesAsync();

    return userUpdated > 0 ? _mapper.Map<UserDTO>(userExists) : throw new UpdateException("um erro ocorreu ao atualizar o usuário");
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }

  }

  public async Task<bool> Remove(string userId)
  {
   try
   {
    UserEntity userExists = await _context.User.FirstOrDefaultAsync(u => u.Id.ToString() == userId) ?? throw new NotFound($"nenhum usuário com o id: {userId} encontrado.");

    _context.User.Remove(userExists);

    int userSuccessfullyRemoved = await _context.SaveChangesAsync();

    return userSuccessfullyRemoved > 0 ? true : throw new RemoveException("um erro ocorreu ao remover o usuário");
   }
   catch (Exception ex)
   {
    throw new Exception(ex.ToString());
   }

  }

  public async Task<UserDTO> User(string userId)
  {
   UserEntity userExists = await _context.User.FirstOrDefaultAsync(u => u.Id.ToString() == userId) ?? throw new NotFound($"nenhum usuário com o id: {userId} encontrado.");

   return _mapper.Map<UserDTO>(userExists);
  }

  public async Task<List<UserDTO>> Users()
  {
   List<UserEntity> users = await _context.User.ToListAsync();
   return users.Count > 0 ? _mapper.Map<List<UserDTO>>(users) : [];
  }
 }
}
