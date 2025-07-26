using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILern.Application.DTO;
using APILern.Application.DTO.AccountUser;
using APILern.Application.DTO.Order;
using APILern.Application.DTO.User;
using APILern.Application.Interfaces;
using APILern.Domain.Entities;
using APILern.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APILern.Application.Services
{
    public class UserService : IUserService
    {
        private readonly ICartService _cartService;
        private readonly IUserRepository _repository;
        public UserService(ICartService cartService, IUserRepository repository)
        {
            _cartService = cartService;
            _repository = repository;
        }

        public async Task<UserProfileDto> GetUserProfileAsync(int UserId)
        {
            var user = await _repository.GetByIdAsync(UserId);
            if (user is null) return null;
            return new UserProfileDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                NumberPhone = user.NumberPhone,
                Role = user.Role,
                Orders = user.Orders.Select(o => new OrderResponseDto
                {
                    OrderNumber = o.Id,
                    OrderItems = o.OrderItems.Select(oi => new OrderItemDto
                    {
                        ProductId = oi.ProductId,
                        Quantity = oi.Quantity
                    }).ToList(),
                    Status = o.Status
                }).ToList(),
            };
        }

        public async Task RegisterAsync(RegisterUserDto dto)
        {
            var existing = await _repository.GetByUserNameAsync(dto.UserName);
            if (existing != null) throw new Exception("Такой пользователь существует");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                NumberPhone = dto.NumberPhone,
                Email = dto.Email,
                PasswordHash = hashedPassword,
                Role = EnumUserRole.Client
            };
            await _repository.AddAsync(user);
            await _cartService.CreateCartAsync(user.Id);
        }

        public async Task<User?> ValidateCredentialsAsync(LoginUserDto dto)
        {
            var user = await _repository.GetByUserNameAsync(dto.UserName);
            if (user == null) return null;

            var isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            return isValid ? user : null;
        }

    }
}