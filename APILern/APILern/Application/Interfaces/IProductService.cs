public interface IProductService
{
    Task<IEnumerable<ProductResponseDto>> GetAllAsync();
    Task<ProductResponseDto?> GetByIdAsync(int id);
    Task<int> AddAsync(AddProductDto dto);
    Task<bool> DeleteAsync(int id);
    Task<ProductResponseDto?> UpdateAsync(int id, UpdateProductDto dto);
}