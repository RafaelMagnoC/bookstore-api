using System.ComponentModel.DataAnnotations;

namespace BookStore.App.Modules.User
{
 public class UserViewModel
 {
  [Required]
  [StringLength(100)]
  public required string Name { get; set; }

  [StringLength(100)]
  [EmailAddress]
  public required string Email { get; set; }

  [Required]
  public required string Password { get; set; }
 }
}
