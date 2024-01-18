using AccountServer.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

[Table("account")]
public class Account : IEntity
{
    [Key]
    [Column("AccountId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Date created is required")]
    public required DateTime DateCreated { get; set; }
    
    [Required(ErrorMessage = "Account type is required")]
    public required string AccountType { get; set; }
    
    [Required(ErrorMessage = "Owner Id is required")]
    public required Guid OwnerId { get; set; }
}