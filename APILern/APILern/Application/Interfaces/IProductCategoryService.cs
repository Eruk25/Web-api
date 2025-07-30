using APILern.Domain.Entities;

namespace APILern.Application.Interfaces
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategory>?> GetAllCategoriesAsync();
        Task<ProductCategory?> GetCategoryById(int id);
        Task AddCategory(ProductCategory category);
        Task DeleteCategory(int id);
    }
}