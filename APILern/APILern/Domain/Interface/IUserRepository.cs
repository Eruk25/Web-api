using APILern.Domain.Entities;

namespace APILern.Domain.Interface;

public interface IUserRepository
{
    Task<User?> GetByUserNameAsync(string userName);
    Task AddAsync(User user);
    Task<User> GetByIdAsync(int id);
}
