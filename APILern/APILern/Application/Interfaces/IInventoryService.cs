using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILern.Application.DTO;
using APILern.Domain.Entities;

namespace APILern.Application.Interfaces
{
    public interface IInventoryService
    {
        Task ReserveProductsAsync(IEnumerable<OrderItemDto> items);

    }
}