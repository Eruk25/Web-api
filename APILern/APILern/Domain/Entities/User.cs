using System.ComponentModel.DataAnnotations;
namespace APILern.Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string PasswordHash { get; set; }
    public EnumUserRole Role { get; set; }
    [Required]
    public string NumberPhone { get; set; }
}