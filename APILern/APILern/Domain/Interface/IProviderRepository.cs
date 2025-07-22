using APILern.Domain.Entities;

namespace APILern.Domain.Interface;

public interface IProviderRepository
{
    Task<IEnumerable<Provider?>> GetAllAsync();
    Task<Provider?> GetByIdAsync(int id);
    Task<int> AddAsync(Provider entity);
    Task<Provider> UpdateAsync(Provider entity);
    Task DeleteAsync(int id);
}
