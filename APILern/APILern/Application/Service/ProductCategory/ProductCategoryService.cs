
using APILern.Application.Interfaces;
using APILern.Domain.Entities;
using APILern.Domain.Interface;

namespace APILern.Application.Service
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task AddCategory(ProductCategory category)
        {
            await _productCategoryRepository.CreateAsync(category);
        }

        public async Task DeleteCategory(int id)
        {
            await _productCategoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductCategory>?> GetAllCategoriesAsync()
        {
            var categories = await _productCategoryRepository.GetAlAsync();
            if (categories is null) return null;
            return categories;
        }

        public async Task<ProductCategory?> GetCategoryById(int id)
        {
            var category = await _productCategoryRepository.GetByIdAsync(id);
            if (category is null) return null;
            return category;
        }
    }
}