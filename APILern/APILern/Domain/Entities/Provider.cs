using System.ComponentModel.DataAnnotations;

namespace APILern.Domain.Entities;

public class Provider
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string NumberPhone { get; set; }
    public List<Product> Products { get; set; } = new();
}
