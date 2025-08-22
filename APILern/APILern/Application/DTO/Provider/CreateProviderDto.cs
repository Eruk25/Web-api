using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APILern.Application.DTO
{
    public class CreateProviderDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string NumberPhone { get; set; }
    }
}