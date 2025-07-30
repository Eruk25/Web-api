using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILern.Application.Interfaces;
using APILern.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APILern.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> GetAllAsync()
        {
            var categories = await _productCategoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetByIdAsync(int id)
        {
            var category = await _productCategoryService.GetCategoryById(id);

            return category is null ? NotFound() : Ok(category);
        }
    }
}