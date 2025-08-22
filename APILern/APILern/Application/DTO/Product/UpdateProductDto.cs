using System.ComponentModel.DataAnnotations;

public class UpdateProductDto
{
    public required string Title { get; set; }
    public required string ImageUrl { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
}
