using System.ComponentModel.DataAnnotations;

namespace BookStore.App.Modules.User
{
 public class UserViewModel
 {
  [Required]
  [StringLength(60)]
  public required string Name { get; set; }

  [Required]
  [StringLength(60)]
  [EmailAddress]
  public required string Email { get; set; }

  [Required]
  [StringLength(20)]
  public required string Password { get; set; }
 }
}
