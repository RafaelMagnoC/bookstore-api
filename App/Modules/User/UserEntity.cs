using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.App.Modules.User
{
 [Table("user")]
 public class UserEntity
 {
  [Key]
  public Guid Id { get; private set; }

  [Column("name", TypeName = "varchar(60)")]
  public string? Name { get; set; }
  [Column("email", TypeName = "varchar(60)")]
  public string? Email { get; set; }
  [Column("password", TypeName = "varchar(20)")]
  public string? Password { get; set; }
  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; }

  public UserEntity(string name, string email, string password)
  {
   Name = name;
   Email = email;
   Password = password;
  }
  public UserEntity() { }
 }
}

