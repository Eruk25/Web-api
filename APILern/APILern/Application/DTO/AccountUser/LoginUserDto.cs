using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APILern.Application.DTO.AccountUser
{
    public class LoginUserDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}