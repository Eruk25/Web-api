using System.ComponentModel.DataAnnotations;

public class UpdateProductDto
{
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
    public int CategoryId { get; set; }
}
