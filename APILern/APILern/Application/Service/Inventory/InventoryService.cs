using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILern.Application.DTO;
using APILern.Application.Interfaces;
using APILern.Domain.Interface;

namespace APILern.Application.Service.Inventory
{
    public class InventoryService : IInventoryService
    {
        private readonly IProductRepository _productRepository;

        public InventoryService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ReserveProductsAsync(IEnumerable<OrderItemDto> items)
        {
            var productIds = items.Select(i => i.ProductId).Distinct();
            var products = await _productRepository.GetByIdsAsync(productIds);

            foreach (var item in items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product == null)
                    throw new Exception($"Товар не найден: {item.ProductId}");

                if (product.Quantity < item.Quantity)
                    throw new Exception($"Недостаточно товара: {product.Title}");
                product.Quantity -= item.Quantity;
            }

            await _productRepository.UpdateRangeAsync(products);
        }
    }
}