using Microsoft.AspNetCore.Identity;

namespace APILern.Application.Service.Pagination
{
    public class PagedResult<T>
    {
        public int TotalCount { get; }
        public List<T> Items { get; }
        public PagedResult(List<T> items, int totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
    }
}