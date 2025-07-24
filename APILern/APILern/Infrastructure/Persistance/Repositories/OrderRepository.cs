using APILern.Domain.Entities;
using APILern.Domain.Interface;
using APILern.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace APILern.Infrastructure.Persistance.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _dbContext;

    public OrderRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Order?>> GetAllAsync()
    {
        return await _dbContext.Orders
            .Include(o => o.OrderItems)
            .ToListAsync();
    }

    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _dbContext.Orders
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAsync(Order entity)
    {
        _dbContext.Orders.Add(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order entity)
    {
        _dbContext.Orders.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var order = await _dbContext.Orders
        .Include(o => o.OrderItems)
        .FirstOrDefaultAsync(o => o.Id == id);

        if (order != null)
        {
            _dbContext.OrderItems.RemoveRange(order.OrderItems);
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
        }
    }
}
