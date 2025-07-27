using System.ComponentModel.DataAnnotations;

public class ProviderResponseDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<ProductShortDto> Products { get; set; } = new();
}
