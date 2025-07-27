using System.ComponentModel.DataAnnotations;
namespace APILern.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    [Required]
    public required string Title { get; set; }
    [Required]
    public required string ImageUrl { get; set; }
    [Required]
    public required string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int ProviderId { get; set; }
    public Provider? Provider { get; set; }

}
