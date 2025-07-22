using APILern.Domain.Entities;
using APILern.Domain.Interface;
using APILern.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace APILern.Infrastructure.Persistance.Repositories;

public class ProviderRepository : IProviderRepository
{
    private readonly AppDbContext _dbContext;

    public ProviderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<Provider?>> GetAllAsync()
    {
        return await _dbContext.Providers.Include(p => p.Products).ToListAsync();
    }

    public async Task<Provider?> GetByIdAsync(int id)
    {
        return await _dbContext.Providers.Include(p => p.Products).FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<int> AddAsync(Provider entity)
    {
        await _dbContext.Providers.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }


    public async Task<Provider> UpdateAsync(Provider entity)
    {
        var existingProvider = await _dbContext.Providers.FirstOrDefaultAsync(u => u.Id == entity.Id);
        if (existingProvider != null)
        {
            existingProvider.Name = entity.Name;
            existingProvider.Email = entity.Email;
            existingProvider.NumberPhone = entity.NumberPhone;
        }
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var provider = await _dbContext.Providers.FindAsync(id);
        if (provider != null)
        {
            _dbContext.Providers.Remove(provider);
            await _dbContext.SaveChangesAsync();
        }
    }
}
