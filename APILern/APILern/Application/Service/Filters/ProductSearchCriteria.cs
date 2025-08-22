namespace APILern.Application.Service.Filters
{
    public class ProductSearchCriteria
    {
        public string? Search { get; set; }
        public string? Category { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }
        public string? Provider { get; set; }
    }

}