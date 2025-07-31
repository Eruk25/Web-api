namespace APILern.Application.DTO
{
    public class ProductCategoryResponseDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public List<ProductResponseDto> Products { get; set; } = new();
    }
}