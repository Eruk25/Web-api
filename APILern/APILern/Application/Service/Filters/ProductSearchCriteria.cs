namespace APILern.Application.Service.Filters
{
    public record CategoryFilter(string Title);
    public record PriceFilter(decimal? MinPrice, decimal? MaxPrice);
    public record ProviderFilter(string ProviderName);
    public class ProductSearchCriteria
    {
        public string? Title { get; set; }
        public CategoryFilter? Category { get; set; }
        public PriceFilter? Price { get; set; }
        public ProviderFilter? Provider { get; set; }
    }

}