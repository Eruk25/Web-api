using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace APILern.Application.DTO
{
    public class UpdateProviderDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string NumberPhone { get; set; }
    }
}