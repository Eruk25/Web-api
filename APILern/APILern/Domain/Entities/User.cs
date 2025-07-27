using System.ComponentModel.DataAnnotations;
namespace APILern.Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Required]
    public required string FirstName { get; set; }
    [Required]
    public required string LastName { get; set; }
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string PasswordHash { get; set; }
    public EnumUserRole Role { get; set; }
    [Required]
    public required string NumberPhone { get; set; }
    public List<Order> Orders { get; set; } = new();

}