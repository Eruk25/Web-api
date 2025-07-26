using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using APILern.Application.DTO.CatItem;
using APILern.Application.DTO.Order;
using APILern.Domain.Entities;

namespace APILern.Application.DTO.User
{
    public class UserProfileDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string? Email { get; set; }
        public string? NumberPhone { get; set; }
        public EnumUserRole Role { get; set; }
        public List<OrderResponseDto> Orders { get; set; } = new();
        public Cart? Cart { get; set; }
    }
}