using APILern.Application.DTO;
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

        public async Task<ProductCategoryResponseDto> AddCategory(AddProductCategoryDto categoryDto)
        {
            var category = new ProductCategory
            {
                Title = categoryDto.Title
            };
            var newCategory = await _productCategoryRepository.CreateAsync(category);
            return new ProductCategoryResponseDto
            {
                Id = newCategory.Id,
                Title = newCategory.Title,
                Products = newCategory.Products.Select(p => new ProductResponseDto
                {
                    Title = p.Title
                }).ToList(),
            };
        }

        public async Task DeleteCategory(int id)
        {
            await _productCategoryRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductCategoryResponseDto>?> GetAllCategoriesAsync()
        {
            var categories = await _productCategoryRepository.GetAlAsync();
            if (categories is null) return null;
            return categories.Select(c => new ProductCategoryResponseDto
            {
                Id = c.Id,
                Title = c.Title,
                Products = c.Products.Select(p => new ProductResponseDto
                {
                    Title = p.Title
                }).ToList(),
            }).ToList();
        }

        public async Task<ProductCategoryResponseDto?> GetCategoryById(int id)
        {
            var category = await _productCategoryRepository.GetByIdAsync(id);
            if (category is null) return null;
            var dto = new ProductCategoryResponseDto
            {
                Title = category.Title,
                Products = category.Products.Select(p => new ProductResponseDto
                {
                    Title = p.Title
                }).ToList()
            };
            return dto;
        }
    }
}