using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILern.Application.DTO.AccountUser;
using APILern.Application.Interfaces;
using APILern.Domain.Entities;
using APILern.Domain.Interface;

namespace APILern.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
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