using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILern.Application.DTO.AccountUser;
using APILern.Domain.Entities;

namespace APILern.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterAsync(RegisterUserDto dto);
        Task<User?> ValidateCredentialsAsync(LoginUserDto dto);
    }
}