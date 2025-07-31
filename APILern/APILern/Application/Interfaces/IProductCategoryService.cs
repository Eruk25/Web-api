using APILern.Application.DTO;

namespace APILern.Application.Interfaces
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoryResponseDto>?> GetAllCategoriesAsync();
        Task<ProductCategoryResponseDto?> GetCategoryById(int id);
        Task<ProductCategoryResponseDto> AddCategory(AddProductCategoryDto categoryDto);
        Task DeleteCategory(int id);
    }
}