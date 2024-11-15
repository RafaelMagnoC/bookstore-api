using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStore.App.Modules.User;

namespace BookStore.App.Modules.Admin
{
 [Table("admin")]
 public class AdminEntity
 {
  [Key]
  public Guid Id { get; private set; }

  [DisplayName("user")]
  public required UserEntity User { get; set; }

 }

}

