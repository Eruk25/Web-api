using System.Security.Cryptography;
using APILern.Application.DTO.Cart;
using APILern.Application.Interfaces;
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

    [HttpPost]
    public async Task<ActionResult> AddToCartAsync(int cartId, int productId, int quantity)
    {
        await _cartService.AddItemAsync(cartId, productId, quantity);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CartResponseAdmin>> GetCartById(int id)
    {
        var cart = await _cartService.GetCartByIdAsync(id);

        return cart is null ? NotFound() : Ok(cart);
    }
}
