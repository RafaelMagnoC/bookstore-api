using System.ComponentModel.DataAnnotations;

namespace BookStore.App.Modules.Auth
{
 public class AuthViewModel(string email, string password)
 {
  [Required]
  [EmailAddress]
  public string Email { get; set; } = email;
  [Required]
  public string Password { get; set; } = password;
 }
}
