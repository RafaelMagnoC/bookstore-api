using AutoMapper;
using BookStore.App.Modules.Admin;
using BookStore.App.Modules.Auth;
using BookStore.App.Modules.User;

namespace BookStore.App.Config
{
 public class EntityToDTOMapping : Profile
 {
  public EntityToDTOMapping()
  {
   CreateMap<UserEntity, UserDTO>();
   CreateMap<AdminEntity, AdminDTO>();
   CreateMap<AuthEntity, AuthDTO>();
  }
 }
}
