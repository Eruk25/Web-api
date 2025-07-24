using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILern.Application.DTO.CatItem;
using APILern.Domain.Entities;

namespace APILern.Application.DTO.Cart
{
    public class CartResponseAdmin
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public List<CartItemDto> Items { get; set; }
    }
}