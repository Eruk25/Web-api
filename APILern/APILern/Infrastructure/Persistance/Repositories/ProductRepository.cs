using APILern.Domain.Entities;
using APILern.Domain.Interface;
using APILern.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace APILern.Infrastructure.Persistance.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Product?>> GetAllAsync()
    {
        return await _dbContext.Products.Include(p => p.Provider).ToListAsync();
    }

    public async Task<Product?> GetByIdAsync(int id)
    {
        return await _dbContext.Products.Include(p => p.Provider).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product> AddAsync(Product entity)
    {
        var newProduct = await _dbContext.Products.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return newProduct.Entity;
    }

    public async Task<Product> UpdateAsync(Product entity)
    {
        var existingProduct = _dbContext.Products.FirstOrDefault(p => p.Id == entity.Id);
        if (existingProduct != null)
        {
            existingProduct.Title = entity.Title;
            existingProduct.ImageUrl = entity.ImageUrl;
            existingProduct.Description = entity.Description;
            existingProduct.Price = entity.Price;
            existingProduct.Quantity = entity.Quantity;
            existingProduct.ProviderId = entity.ProviderId;
        }

        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);
        if (product is null) return;

        _dbContext.Products.Remove(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product?>> GetByIdsAsync(IEnumerable<int> ids)
    {
        var products = await _dbContext.Products.Where(p => ids.Contains(p.Id)).ToListAsync();
        return products;
    }

    public async Task UpdateRangeAsync(IEnumerable<Product> products)
    {
        _dbContext.UpdateRange(products);
        await _dbContext.SaveChangesAsync();
    }
}
