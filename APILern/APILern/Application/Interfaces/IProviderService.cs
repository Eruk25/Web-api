using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILern.Application.DTO;

namespace APILern.Application.Interfaces
{
    public interface IProviderService
    {
        Task<IEnumerable<ProviderResponseDto>> GetAllAsync();
        Task<ProviderResponseDto?> GetByIdAsync(int id);
        Task<int> AddAsync(CreateProviderDto dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateProviderDto dto);
    }
}