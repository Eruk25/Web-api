using APILern.Application.DTO;
using APILern.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CartsController : ControllerBase
{
    private readonly ICartService _cartService;

    public CartsController(ICartService cartService)
    {
        _cartService = cartService;
    }
    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddToCartAsync(int cartId, int productId, int quantity)
    {
        await _cartService.AddItemAsync(cartId, productId, quantity);
        return Ok();
    }
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<CartResponseAdmin>> GetCartById(int id)
    {
        var cart = await _cartService.GetCartByIdAsync(id);

        return cart is null ? NotFound() : Ok(cart);
    }
}
