using System.ComponentModel.DataAnnotations;

public class AddProductDto
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше нуля.")]
    public decimal Price { get; set; }
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Количество должно быть не менее 1.")]
    public int Quantity { get; set; }
    [Required(ErrorMessage = "Укажите ID поставщика.")]
    public int ProviderId { get; set; }
}
