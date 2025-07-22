using APILern.Domain.Entities;

namespace APILern.Domain.Interface;

public interface IProductRepository
{
    Task<IEnumerable<Product?>> GetAllAsync();
    Task<Product?> GetByIdAsync(int id);
    Task<Product> AddAsync(Product entity);
    Task<Product> UpdateAsync(Product entity);
    Task DeleteAsync(int id);
}
