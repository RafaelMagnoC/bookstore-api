using System.ComponentModel.DataAnnotations;
using BookStore.App.Modules.User;

namespace BookStore.App.Modules.Admin
{
 public class AdminViewModel()
 {
  [Required]
  public required UserViewModel User { get; set; }
 }
}
