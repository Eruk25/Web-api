using System.Security.Authentication;
using APILern.Domain.Entities;
using APILern.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

public class CartRepository : ICartRepository
{
    private readonly AppDbContext _context;
    public CartRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Cart cart)
    {
        await _context.Carts.AddAsync(cart);
        await _context.SaveChangesAsync();
    }

    public async Task AddItemAsync(int cartId, int productId, int quantity)
    {
        var item = await _context.CartItems
        .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);
        if (item != null)
        {
            item.Quantity += quantity;
        }
        else
        {
            var newItem = new CartItem
            {
                CartId = cartId,
                ProductId = productId,
                Quantity = quantity
            };
            await _context.CartItems.AddAsync(newItem);
        }
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAllAsync(int cartId)
    {
        var items = await _context.CartItems
        .Where(ci => ci.CartId == cartId).ToListAsync();
        if (items.Count == 0) return;
        _context.CartItems.RemoveRange(items);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.CartItems.FindAsync(id);
        if (item is null) return;
        _context.CartItems.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<Cart> GetByUserIdAsync(int clientId)
    {
        var cart = await _context.Carts
            .Include(c => c.Items)
            .FirstOrDefaultAsync(c => c.ClientId == clientId);

        return cart;
    }

    public async Task<Cart> GetCartByIdAsync(int cartId)
    {
        var cart = await _context.Carts
                    .Include(c => c.Items)
                    .FirstOrDefaultAsync(c => c.Id == cartId);
        return cart;
    }

    public async Task UpdateQuantityAsync(int cartId, int productId, int newQuantity)
    {
        var item = await _context.CartItems
        .FirstOrDefaultAsync(ci => ci.CartId == cartId && ci.ProductId == productId);

        if (item is null) return;

        item.Quantity = newQuantity;
        await _context.SaveChangesAsync();
    }
}