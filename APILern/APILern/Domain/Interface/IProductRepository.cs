using APILern.Domain.Entities;

namespace APILern.Domain.Interface;

public interface IProductRepository
{
    Task<IEnumerable<Product?>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<IEnumerable<Product?>> GetByIdsAsync(IEnumerable<int> ids);
    Task<Product> AddAsync(Product entity);
    Task<Product> UpdateAsync(Product entity);
    Task UpdateRangeAsync(IEnumerable<Product> products);
    Task DeleteAsync(int id);
}
