using APILern.Application.Service.Filters;
using APILern.Application.Service.Pagination;
using APILern.Application.Service.Sort;

public interface IProductService
{
    Task<PagedResult<ProductResponseDto>> GetAllAsync(ProductSortCriteria productSort, PageParams pageParams, ProductSearchCriteria productSearch);
    Task<ProductResponseDto?> GetByIdAsync(int id);
    Task<int> AddAsync(AddProductDto dto);
    Task<bool> DeleteAsync(int id);
    Task<ProductResponseDto?> UpdateAsync(int id, UpdateProductDto dto);
}