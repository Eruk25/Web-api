using APILern.Domain.Entities;
using APILern.Domain.Interface;

namespace APILern.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<ProductResponseDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        return products.Select(p => new ProductResponseDto
        {
            Title = p!.Title,
            Description = p.Description,
            Quantity = p.Quantity,
            Price = p.Price,
            ProviderName = p.Provider!.Name
        }).ToList();
    }

    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return null;
        var dto = new ProductResponseDto
        {
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            ProviderName = product.Provider?.Name ?? "-",
        };
        return dto;
    }

    public async Task<int> AddAsync(AddProductDto dto)
    {
        var product = new Product
        {
            Title = dto.Title,
            ImageUrl = dto.ImageUrl,
            Description = dto.Description,
            Price = dto.Price,
            Quantity = dto.Quantity,
            ProviderId = dto.ProviderId,
        };

        await _repository.AddAsync(product);
        return product.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return false;

        await _repository.DeleteAsync(id);
        return true;
    }

    public async Task<ProductResponseDto?> UpdateAsync(int id, UpdateProductDto dto)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product is null) return null;

        product.Title = dto.Title;
        product.ImageUrl = dto.ImageUrl;
        product.Description = dto.Description;
        product.Price = dto.Price;
        product.Quantity = dto.Quantity;
        await _repository.UpdateAsync(product);
        return new ProductResponseDto
        {
            Title = product.Title,
            Description = product.Description,
            Quantity = product.Quantity,
            Price = product.Price,
            ProviderName = product.Provider?.Name ?? "-"
        };
    }
}