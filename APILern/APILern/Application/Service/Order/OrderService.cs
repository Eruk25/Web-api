using APILern.Application.DTO;
using APILern.Application.DTO.Order;
using APILern.Application.Interfaces;
using APILern.Domain.Entities;
using APILern.Domain.Enums;
using APILern.Domain.Interface;

namespace APILern.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(ICartRepository cartRepository, IOrderRepository orderRepository)
        {
            _cartRepository = cartRepository;
            _orderRepository = orderRepository;
        }

        public async Task<bool> CancelOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order is null) return false;

            await _orderRepository.DeleteAsync(id);
            return true;
        }

        public async Task<OrderResponseDto> CreateOrderAsync(int CartId)
        {
            var cart = await _cartRepository.GetCartByIdAsync(CartId);
            if (cart is null || cart.Items.Count == 0) return null;
            var order = new Order
            {
                UserId = cart.ClientId,
                PaymentDate = DateTime.UtcNow,
                Status = EnumPaymentStatus.Pending,
                OrderItems = cart.Items.Select(item => new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                }).ToList(),
            };
            var dto = new OrderResponseDto
            {
                OrderNumber = order.Id,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity
                }).ToList(),
                Status = order.Status
            };
            await _orderRepository.AddAsync(order);
            await _cartRepository.DeleteAllAsync(CartId);
            return dto;
        }

        public async Task<IEnumerable<OrderResponseDto>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetAllAsync();

            return orders.Select(order => new OrderResponseDto
            {
                OrderNumber = order.Id,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity
                }).ToList(),
                Status = order.Status
            }).ToList();
        }

        public async Task<OrderResponseDto> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);
            if (order is null) return null;

            var dto = new OrderResponseDto
            {
                OrderNumber = order.Id,
                OrderItems = order.OrderItems.Select(oi => new OrderItemDto
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity
                }).ToList(),
                Status = order.Status,
            };
            return dto;
        }
    }
}