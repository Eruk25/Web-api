using APILern.Application.DTO;
using APILern.Application.Interfaces;
using APILern.Domain.Entities;
using APILern.Domain.Interface;

namespace APILern.Application.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _repository;

        public ProviderService(IProviderRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ProviderResponseDto>> GetAllAsync()
        {
            var providers = await _repository.GetAllAsync();
            if (providers is null)
                return Enumerable.Empty<ProviderResponseDto>();
            return providers.Select(p => new ProviderResponseDto
            {
                Id = p!.Id,
                Name = p.Name,
                Products = p.Products.Select(prod => new ProductShortDto
                {
                    Title = prod.Title,
                    Price = prod.Price,
                    Quantity = prod.Quantity
                }).ToList()
            }).ToList();
        }

        public async Task<ProviderResponseDto?> GetByIdAsync(int id)
        {
            var provider = await _repository.GetByIdAsync(id);
            if (provider is null) return null;
            var dto = new ProviderResponseDto
            {
                Id = provider.Id,
                Name = provider.Name,
                Products = provider.Products.Select(prod => new ProductShortDto
                {
                    Title = prod.Title,
                    Price = prod.Price,
                    Quantity = prod.Quantity
                }).ToList()
            };

            return dto;
        }
        public async Task<int> AddAsync(CreateProviderDto dto)
        {
            var newProvider = new Provider
            {
                Name = dto.Name,
                Email = dto.Email,
                NumberPhone = dto.NumberPhone
            };
            return await _repository.AddAsync(newProvider);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var provider = await _repository.GetByIdAsync(id);
            if (provider is null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }


        public async Task<bool> UpdateAsync(int id, UpdateProviderDto dto)
        {
            var provider = await _repository.GetByIdAsync(id);
            if (provider is null) return false;
            provider.Name = dto.Name;
            provider.Email = dto.Email;
            provider.NumberPhone = dto.NumberPhone;
            await _repository.UpdateAsync(provider);
            return true;
        }
    }
}