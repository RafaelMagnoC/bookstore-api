using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.App.Modules.User
{
 [Table("user")]
 public class UserEntity(string name, string email, string password)
 {
  [Key]
  public Guid Id { get; private set; }

  [Required]
  [StringLength(100)]
  public string Name { get; set; } = name;

  [StringLength(100)]
  [EmailAddress]
  public string Email { get; set; } = email;

  [Required]
  public string Password { get; set; } = password;

  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
 }
}

