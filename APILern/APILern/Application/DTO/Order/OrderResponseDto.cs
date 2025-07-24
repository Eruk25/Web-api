using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILern.Domain.Entities;
using APILern.Domain.Enums;

namespace APILern.Application.DTO.Order
{
    public class OrderResponseDto
    {
        public int OrderNumber { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public int Quantity { get; set; }
        public EnumPaymentStatus Status { get; set; }
    }
}