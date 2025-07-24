using APILern.Domain.Entities;

public interface ICartRepository
{
    Task AddAsync(Cart cart);
    Task AddItemAsync(int cartId, int productId, int quantity);
    Task UpdateQuantityAsync(int cartId, int productId, int newQuantity);
    Task DeleteAllAsync(int cartId);
    Task DeleteAsync(int id);
    Task<Cart> GetByUserIdAsync(int clientId);
    Task<Cart> GetCartByIdAsync(int cartId);
}