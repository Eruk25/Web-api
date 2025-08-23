using APILern.Application.DTO;
using APILern.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<IEnumerable<ProductCategoryResponseDto>>> GetAllAsync()
        {
            var categories = await _productCategoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}", Name = "GetByIdAsync")]
        public async Task<ActionResult<ProductCategoryResponseDto>> GetByIdAsync(int id)
        {
            var category = await _productCategoryService.GetCategoryById(id);

            return category is null ? NotFound() : Ok(category);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<ProductCategoryResponseDto>> AddAsync([FromBody] AddProductCategoryDto categoryDto)
        {
            var newCategory = await _productCategoryService.AddCategory(categoryDto);

            return CreatedAtRoute("GetByIdAsync", new { id = newCategory.Id }, new { id = newCategory.Id });
        }
    }
}