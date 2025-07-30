namespace APILern.Domain.Entities
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}