using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.App.Modules.Auth
{
 [Table("auth")]
 public class AuthEntity(string userId, string email, string password, string token)
 {
  [Key]
  public Guid Id { get; set; }
  [Required]
  public string UserId { get; set; } = userId;
  [Required]
  public string Email { get; set; } = email;
  [Required]
  public string Password { get; set; } = password;
  [Required]
  public string Token { get; set; } = token;
 }
}
