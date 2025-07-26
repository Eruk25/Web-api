using APILern.Application.DTO;

namespace APILern.Application.Interfaces
{
    public interface ICartService
    {
        Task AddItemAsync(int cartId, int productId, int quantity);
        Task RemoveItemAsync(int cartId, int productId);
        Task UpdateQuantityAsync(int cartId, int productId, int quantity);
        Task ClearCartAsync(int cartId);
        Task CreateCartAsync(int ClientId);
        Task<CartResponseAdmin?> GetCartByIdAsync(int clientId);
    }
}