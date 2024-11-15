namespace BookStore.App.Modules.Admin
{
 public interface IAdminRepository
 {
  Task<AdminDTO> AdminAdd(AdminViewModel adminViewModel);

  Task<List<AdminDTO>> Admins();

  Task<AdminDTO> Admin(string adminId);

  Task<AdminDTO> AdminAt(string adminId, AdminViewModel adminViewModel);

  Task<bool> AdminRemove(string adminId);
 }
}
