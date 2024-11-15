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
  [Column("user_id", TypeName = "varchar(60)")]
  public string UserId { get; set; } = userId;
  [Required]
  [Column("user_email", TypeName = "varchar(60)")]
  public string Email { get; set; } = email;
  [Required]
  [Column("user_password", TypeName = "varchar(60)")]
  public string Password { get; set; } = password;
  [Required]
  [Column("user_token", TypeName = "varchar(60)")]
  public string Token { get; set; } = token;
 }
}
