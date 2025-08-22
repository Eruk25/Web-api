using APILern.Application.Service.Filters;
using APILern.Application.Service.Pagination;
using APILern.Application.Service.Sort;
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
    public async Task<PagedResult<ProductResponseDto>> GetAllAsync(ProductSortCriteria productSort, PageParams pageParams, ProductSearchCriteria productSearch)
    {
        var pagedResult = await _repository.GetAllAsync(productSort, pageParams, productSearch);

        var dtoItems = pagedResult.Items.Select(p => new ProductResponseDto
        {
            Id = p!.Id,
            Title = p!.Title,
            Description = p.Description,
            Quantity = p.Quantity,
            Price = p.Price,
            ProviderName = p.Provider?.Name ?? "-",
            Category = p.ProductCategory?.Title ?? "Без категории"
        }).ToList();

        return new PagedResult<ProductResponseDto>(dtoItems, pagedResult.TotalCount);
    }
    public async Task<ProductResponseDto?> GetByIdAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return null;
        var dto = new ProductResponseDto
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            ProviderName = product.Provider?.Name ?? "-",
            Category = product.ProductCategory?.Title ?? "Без категории"
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
            ProductCategoryId = dto.CategoryId,
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
        product.ProductCategoryId = dto.CategoryId;
        await _repository.UpdateAsync(product);
        return new ProductResponseDto
        {
            Title = product.Title,
            Description = product.Description,
            Quantity = product.Quantity,
            Price = product.Price,
            ProviderName = product.Provider?.Name ?? "-",
            Category = product.ProductCategory?.Title ?? "Без категории"
        };
    }
}