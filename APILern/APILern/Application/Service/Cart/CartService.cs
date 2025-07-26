using APILern.Application.DTO;
using APILern.Application.DTO.CatItem;
using APILern.Application.Interfaces;
using APILern.Domain.Entities;

namespace APILern.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;
        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public async Task AddItemAsync(int cartId, int productId, int quantity)
        {
            await _repository.AddItemAsync(cartId, productId, quantity);
        }

        public async Task ClearCartAsync(int cartId)
        {
            var cart = await _repository.GetCartByIdAsync(cartId);
            if (cart is null || cart.Items.Count == 0) return;

            await _repository.DeleteAllAsync(cartId);
        }

        public async Task CreateCartAsync(int ClientId)
        {
            var cart = new Cart
            {
                ClientId = ClientId,
            };
            await _repository.AddAsync(cart);
        }

        public async Task<CartResponseAdmin?> GetCartByIdAsync(int id)
        {
            var cart = await _repository.GetByUserIdAsync(id);
            if (cart is null) return null;
            var dto = new CartResponseAdmin
            {
                Id = cart.Id,
                ClientId = cart.ClientId,
                Items = cart.Items.Select(i => new CartItemDto
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity
                }).ToList()
            };
            return dto;
        }

        public async Task RemoveItemAsync(int cartId, int productId)
        {
            var cart = await _repository.GetCartByIdAsync(cartId);
            if (cart is null || cart.Items.Count == 0) return;

            await _repository.DeleteAsync(productId);
        }

        public async Task UpdateQuantityAsync(int cartId, int productId, int quantity)
        {
            var cart = await _repository.GetCartByIdAsync(cartId);
            if (cart is null || cart.Items.Count == 0) return;

            await _repository.UpdateQuantityAsync(cartId, productId, quantity);
        }
    }
}