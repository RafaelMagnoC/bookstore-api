using AutoMapper;
using BookStore.App.Exceptions;
using BookStore.App.Modules.User;
using BookStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookStore.App.Modules.Admin
{
 public class AdminRepository(ApplicationDbContext context, IMapper mapper) : IAdminRepository
 {
  private readonly ApplicationDbContext _context = context;
  private readonly IMapper _mapper = mapper;
  public async Task<AdminDTO> AdminAdd(AdminViewModel adminViewModel)
  {
   try
   {
    UserEntity user = new(adminViewModel.User.Name, adminViewModel.User.Email, adminViewModel.User.Password);
    AdminEntity admin = new() { User = user };
    EntityEntry<AdminEntity> adminCreated = await _context.Admin.AddAsync(admin);
    int adminSave = await _context.SaveChangesAsync();
    return adminSave > 0 ? _mapper.Map<AdminDTO>(adminCreated.Entity) : throw new CreateException("um erro ocorreu ao cadastrar o administrador");
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }

  }

  public async Task<AdminDTO> Admin(string adminId)
  {
   try
   {
    AdminEntity? admin = await _context.Admin.Include(u => u.User).FirstOrDefaultAsync(adm => adm.Id.ToString() == adminId);
    return admin != null ? _mapper.Map<AdminDTO>(admin) : throw new NotFound($"nenhum administrador com o id: {adminId} encontrado.");
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }

  }

  public async Task<List<AdminDTO>> Admins()
  {
   try
   {
    List<AdminEntity> admins = await _context.Admin.Include(u => u.User).ToListAsync();
    return admins.Count > 0 ? _mapper.Map<List<AdminDTO>>(admins) : [];
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }

  }

  public async Task<AdminDTO> AdminAt(string adminId, AdminViewModel adminViewModel)
  {
   try
   {
    AdminEntity? admin = await _context.Admin.Include(u => u.User).FirstOrDefaultAsync(adm => adm.Id.ToString() == adminId) ?? throw new NotFound($"nenhum administrador com o id: {adminId} encontrado.");
    (string Name, string Email, string Password) = (adminViewModel.User.Name, adminViewModel.User.Email, adminViewModel.User.Password);

    admin.User.Name = Name;
    admin.User.Email = Email;
    admin.User.Password = Password;
    admin.User.UpdatedAt = DateTime.Now;

    _context.Update(admin);
    int adminAt = await _context.SaveChangesAsync();

    return adminAt > 0 ? _mapper.Map<AdminDTO>(admin) : throw new UpdateException("um erro ocorreu ao atualizar o administrador");
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }

  }

  public async Task<bool> AdminRemove(string adminId)
  {
   try
   {
    AdminEntity? admin = await _context.Admin.FirstOrDefaultAsync(adm => adm.Id.ToString() == adminId) ?? throw new NotFound($"nenhum administrador com o id: {adminId} encontrado.");

    _context.Remove(admin);

    int adminRemoved = await _context.SaveChangesAsync();

    return adminRemoved > 0 ? true : throw new RemoveException("um erro ocorreu ao remover o administrador.");
   }
   catch (Exception exception)
   {
    throw new Exception(exception.ToString());
   }

  }
 }
}
