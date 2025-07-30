using APILern.Domain.Entities;

namespace APILern.Domain.Interface
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAlAsync();
        Task<ProductCategory> GetByIdAsync(int id);
        Task CreateAsync(ProductCategory category);
        Task DeleteAsync(int id);
    }
}