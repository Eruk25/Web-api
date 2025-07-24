using APILern.Application.DTO.Order;
using APILern.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APILern.Controller;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult<OrderResponseDto>> CreateOrderAsync([FromQuery] int CartId)
    {
        var order = await _orderService.CreateOrderAsync(CartId);

        return order is null ? BadRequest() : Ok(order);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderResponseDto>> GetOrderByIdAsync(int id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteOrderAsync(int id)
    {
        var success = await _orderService.CancelOrderAsync(id);
        return success ? Ok() : BadRequest();
    }
}
