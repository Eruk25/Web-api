using APILern.Application.Service.Filters;
using APILern.Application.Service.Pagination;
using APILern.Application.Service.Sort;
using APILern.Domain.Entities;
using Azure;

namespace APILern.Domain.Interface;

public interface IProductRepository
{
    Task<PagedResult<Product>> GetAllAsync(ProductSortCriteria productSort, PageParams pageParams);
    Task<IEnumerable<Product?>> GetProductByParamsIdAsync(ProductSearchCriteria productSearch);
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product?>> GetByIdsAsync(IEnumerable<int> ids);
    Task<Product> AddAsync(Product entity);
    Task<Product> UpdateAsync(Product entity);
    Task UpdateRangeAsync(IEnumerable<Product> products);
    Task DeleteAsync(int id);
}
