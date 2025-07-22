using System.ComponentModel.DataAnnotations;
namespace APILern.Domain.Entities;

public class Product
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public int ProviderId { get; set; }
    public Provider? Provider { get; set; }

}
