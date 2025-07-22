using APILern.Application.DTO.Order;
using APILern.Domain.Entities;

namespace APILern.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync();
        Task<OrderResponseDto> GetOrderByIdAsync(int id);
        Task CreateOrderAsync(Order order);
        Task<bool> CancelOrderAsync(int id);
    }
}